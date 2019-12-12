using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(WeaponManager))]
public class CombatManager : MonoBehaviour
{
    public float timeToZoomIn;
    public float zoomInAmount;
    public bool isPlayer;

    private static readonly string HEALTH_PARAMETER = "Health";
    private static readonly string DEATH_TRIGGER = "Death";
    private static readonly string SHOOT_TRIGGER = "Shoot";
    private static readonly string SHOOT_SPEED = "ShootSpeed";
    private static readonly string SHOOT_ANIMATIONS = "ShootAnimations";
    private static readonly string SHOOT_ANIMATION_TYPE = "RandomShoot";
    private static readonly string RELOAD_TRIGGER = "Reload";
    private static readonly string RELOAD_SPEED = "ReloadSpeed";
    private static readonly string DEATH_ANIMATION_TYPE = "RandomDeath";
    private static readonly string DEATH_ANIMATIONS = "DeathAnimations";
    private static readonly string AIMING_TRIGGER = "Aiming";
    private static readonly float DESTROY_DELAY_SECONDS = 5f;

    private static readonly Dictionary<int, string> SWING_ANIMATION_TYPES = new Dictionary<int, string>
    {
        [1] = "Downward Swing",
        [2] = "Horizontal Swing",
        [3] = "Upward Swing"
    };

    private float health;
    private float damageReductionPercentage;
    private float damageExtraPercentage;
    private float speedExtraPercentage;
    private float healthExtraPercentage;
    private bool aiming;
    private float lastLeftClick;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animController;
    private WeaponManager weaponManager;
    private AnimationClip reloadAnimation = null;
    private AnimationClip shootAnimation = null;
    private List<AnimationClip> swingAnimations;
    private float originalZoom;
    private float zoomTimer;
    private bool dying;

    public float Health
    {
        get { return health * (1 + HealthExtraPercentage); }
        set { health = value; }
    }

    public float DamageReductionPercentage
    {
        get { return damageReductionPercentage; }
        set { damageReductionPercentage = value; }
    }

    public float DamageExtraPercentage
    {
        get { return damageReductionPercentage; }
        set { damageExtraPercentage = value; }
    }

    public float SpeedExtraPercentage
    {
        get { return speedExtraPercentage; }
        set { speedExtraPercentage = value; }
    }

    public float HealthExtraPercentage
    {
        get { return healthExtraPercentage; }
        set { healthExtraPercentage = value; }
    }

    public WeaponManager WeaponManager
    {
        get { return weaponManager; }
    }

    public bool Aiming
    {
        get { return aiming; }
    }

    void Start()
    {
        health = 100f;
        damageReductionPercentage = 0f;
        damageReductionPercentage = 0f;
        speedExtraPercentage = 0f;
        healthExtraPercentage = 0f;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animController = GetComponent<Animator>();
        weaponManager = GetComponent<WeaponManager>();
        aiming = false;
        originalZoom = Camera.main.fieldOfView;
        zoomTimer = timeToZoomIn;
        lastLeftClick = 0;
        swingAnimations = new List<AnimationClip>();
        dying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0 && !dying)
        {
            dying = true;
            if(agent != null)
            {
                GetComponent<AIControl>().target = null;
                agent.speed = 0;
                agent = null;
            }
            animController.SetTrigger(DEATH_TRIGGER);
            var deathAnimation = Random.Range(1, animController.GetInteger(DEATH_ANIMATIONS) + 1);
            animController.SetInteger(DEATH_ANIMATION_TYPE, deathAnimation);
            Destroy(gameObject, DESTROY_DELAY_SECONDS);
            if(!isPlayer)
            {
                var GUI = GameObject.FindWithTag("GUI");
                if(GUI != null)
                {
                    var score = 0;
                    if(WeaponSettings.IsPistol(weaponManager.CurrentWeapon.gameObject.tag))
                    {
                        score += 10;
                    }
                    else if(WeaponSettings.IsRifle(weaponManager.CurrentWeapon.gameObject.tag))
                    {
                        score += 30;
                    }
                    else if(WeaponSettings.IsLightsaber(weaponManager.CurrentWeapon.gameObject.tag))
                    {
                        score += 70;
                    }

                    GUI.GetComponent<GuiManager>().Score += score;
                }
            }
        }
        else if(!dying)
        {
            if(agent != null)
            {
                agent.speed = agent.speed * (1 + SpeedExtraPercentage);
            }

            if(isPlayer)
            {
                var aim = Input.GetAxis("Fire2");
                var fire = Input.GetAxis("Fire1");
                var reload = Input.GetAxis("Reload");

                if(!aiming && aim != 0
                || aiming && aim == 0)
                {
                    ToggleAiming();
                }

                if(zoomTimer < timeToZoomIn)
                {
                    var zoom = aiming ? -1 : 1;
                    Camera.main.fieldOfView += (zoomInAmount * zoom) * Time.fixedDeltaTime;
                    zoomTimer += Time.fixedDeltaTime;
                }

                if((fire > 0 && lastLeftClick == 0) && aiming && weaponManager.WeaponComponent.CanAttack())
                {
                    Attack();
                }

                lastLeftClick = fire;

                if(reload != 0)
                {
                    var gun = weaponManager.CurrentWeapon.GetComponent<GunWeapon>();
                    if(gun != null && !gun.Reloading)
                    {
                        if(reloadAnimation == null)
                        {
                            GetClips();
                        }
                        gun.Reloading = true;
                        gun.PlayReloadSound();
                        animController.SetFloat(RELOAD_SPEED, reloadAnimation.length / gun.ReloadTime);
                        animController.SetTrigger(RELOAD_TRIGGER);
                    }
                }
            }
        }
    }

    public void ToggleAiming()
    {
        animController.SetTrigger(AIMING_TRIGGER);
        aiming = !aiming;
        zoomTimer = 0;
        var lightsaberComponent = weaponManager.CurrentWeapon.GetComponent<LightsaberWeapon>();
        if(lightsaberComponent != null)
        {
            lightsaberComponent.ToggleWeaponOnOff();
        }
    }

    public void Attack()
    {
        var gun = weaponManager.CurrentWeapon.GetComponent<GunWeapon>();
        if(gun != null)
        {
            if(shootAnimation == null)
            {
                GetClips();
            }
            animController.SetFloat(SHOOT_SPEED, shootAnimation.length / gun.TimeBetweenShots);
        }
        else
        {
            var lightsaber = weaponManager.CurrentWeapon.GetComponent<LightsaberWeapon>();
            if(lightsaber != null)
            {
                if(swingAnimations.Count == 0)
                {
                    GetClips();
                }
                var shootAnimation = Random.Range(1, animController.GetInteger(SHOOT_ANIMATIONS) + 1);
                var swingLength = 1f;
                foreach(var animation in swingAnimations)
                {
                    if(animation.name == SWING_ANIMATION_TYPES[shootAnimation])
                    {
                        swingLength = animation.length;
                        break;
                    }
                }
                animController.SetFloat(SHOOT_SPEED, swingLength / lightsaber.TimeBetweenSwings);
                animController.SetInteger(SHOOT_ANIMATION_TYPE, shootAnimation);
            }
        }
        animController.SetTrigger(SHOOT_TRIGGER);
        weaponManager.WeaponComponent.Attack();
    }

    private void DoneShooting()
    {
        var lightsaber = weaponManager.CurrentWeapon.GetComponent<LightsaberWeapon>();
        if(lightsaber != null)
        {
            lightsaber.DoneAttack();
        }
    }

    private void DoneReloading()
    {
        var gun = weaponManager.WeaponComponent.GetComponent<GunWeapon>();
        if(gun != null)
        {
            gun.Reload();
        }
    }

    private void GetClips()
    {
        var clips = animController.runtimeAnimatorController.animationClips;
        foreach(var clip in clips)
        {
            if(clip.name.Contains(RELOAD_TRIGGER))
            {
                reloadAnimation = clip;
            }
            else if(clip.name.Contains(SHOOT_TRIGGER))
            {
                shootAnimation = clip;
            }
            else if(clip.name.Contains("Swing"))
            {
                swingAnimations.Add(clip);
            }
        }
    }
}