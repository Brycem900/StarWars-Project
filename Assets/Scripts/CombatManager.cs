using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(WeaponManager))]
[RequireComponent(typeof(CharacterControl))]
public class CombatManager : MonoBehaviour
{
    public float timeToZoomIn;
    public float zoomInAmount;
    public bool isPlayer;

    private static readonly string HEALTH_PARAMETER = "Health";
    private static readonly string SHOOT_TRIGGER = "Shoot";
    private static readonly string SHOOT_SPEED = "ShootSpeed";
    private static readonly string SHOOT_ANIMATIONS = "ShootAnimations";
    private static readonly string SHOOT_ANIMATION_TYPE = "RandomShoot";
    private static readonly string RELOAD_TRIGGER = "Reload";
    private static readonly string RELOAD_SPEED = "ReloadSpeed";
    private static readonly string DEATH_ANIMATION_TYPE = "RandomDeath";
    private static readonly string DEATH_ANIMATIONS = "DeathAnimations";
    private static readonly string AIMING_BOOL = "Aiming";
    private static readonly float DESTROY_DELAY_SECONDS = 5f;
    private static readonly float LIGHTSABER_BLOCKING_REDUCTION = 0.3f;

    private static readonly Dictionary<int, string> SWING_ANIMATION_TYPES = new Dictionary<int, string>
    {
        [1] = "Downward Swing",
        [2] = "Horizontal Swing",
        [3] = "Upward Swing"
    };

    [SerializeField]
    private float health;

    [SerializeField]
    private float damageReductionPercentage;

    [SerializeField]
    private float damageExtraPercentage;

    [SerializeField]
    private float speedExtraPercentage;

    private bool aiming;
    private float lastLeftClick;
    private UnityEngine.AI.NavMeshAgent agent;
    private AIControl AI;
    private CharacterControl characterControl;
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
        get { return health; }
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

    public WeaponManager WeaponManager
    {
        get { return weaponManager; }
    }

    public bool Aiming
    {
        get { return aiming; }
    }

    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        AI = GetComponent<AIControl>();
        animController = GetComponent<Animator>();
        weaponManager = GetComponent<WeaponManager>();
        characterControl = GetComponent<CharacterControl>();
        aiming = false;
        originalZoom = Camera.main.fieldOfView;
        zoomTimer = timeToZoomIn;
        lastLeftClick = 0;
        swingAnimations = new List<AnimationClip>();
        dying = false;
    }

    void Update()
    {
        if(!dying)
        {
            if(Health <= 0)
            {
                characterControl.ForceStop = true;
                Health = 0;
                dying = true;
                var deathAnimation = Random.Range(1, animController.GetInteger(DEATH_ANIMATIONS) + 1);
                animController.SetInteger(DEATH_ANIMATION_TYPE, deathAnimation);
                Destroy(gameObject, DESTROY_DELAY_SECONDS);
                if(!isPlayer)
                {
                    AI.target = null;
                    AI.Agent.speed = 0;
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
            else
            {
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
                        ReloadGun();
                    }
                }
                else
                {
                    AI.Agent.speed *= (1 + SpeedExtraPercentage);
                    if(AI.target != null)
                    {
                        var targetCombat = AI.target.GetComponent<CombatManager>();
                        if(targetCombat != null)
                        {
                            if(targetCombat.Health > 0)
                            {
                                if(AI.Agent.remainingDistance <= AI.Agent.stoppingDistance * 0.95
                                && AI.IsFacingTarget())
                                {
                                    if(weaponManager.WeaponComponent is GunWeapon)
                                    {
                                        var gun = weaponManager.WeaponComponent as GunWeapon;
                                        if(gun.NeedToReload())
                                        {
                                            ReloadGun();
                                        }
                                    }

                                    if(weaponManager.WeaponComponent.CanAttack())
                                    {
                                        Attack();
                                    }
                                }
                            }
                            else
                            {
                                AI.target = null;
                            }
                        }
                    }
                }
            }
        }
    }

    public void ReloadGun()
    {
        var gun = weaponManager.WeaponComponent as GunWeapon;
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

    public void ToggleAiming()
    {
        aiming = !aiming;
        animController.SetBool(AIMING_BOOL, aiming);
        zoomTimer = 0;
        if(weaponManager.WeaponComponent is LightsaberWeapon)
        {
            var lightsaberComponent = weaponManager.WeaponComponent as LightsaberWeapon;
            lightsaberComponent.ToggleWeaponOnOff();
            if(aiming)
            {
                damageReductionPercentage += LIGHTSABER_BLOCKING_REDUCTION;
            }
            else
            {
                damageReductionPercentage -= LIGHTSABER_BLOCKING_REDUCTION;
            }
        }
    }

    public void Attack()
    {
        if(weaponManager.WeaponComponent is GunWeapon)
        {
            var gun = weaponManager.WeaponComponent as GunWeapon;
            if(shootAnimation == null)
            {
                GetClips();
            }
            animController.SetFloat(SHOOT_SPEED, shootAnimation.length / gun.TimeBetweenShots);
        }
        else if(weaponManager.WeaponComponent is LightsaberWeapon)
        {
            var lightsaber = weaponManager.WeaponComponent as LightsaberWeapon;
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
        animController.SetTrigger(SHOOT_TRIGGER);
        weaponManager.WeaponComponent.Attack();
    }

    private void DoneShooting()
    {
        var lightsaber = weaponManager.WeaponComponent as LightsaberWeapon;
        if(lightsaber != null)
        {
            lightsaber.DoneAttack();
        }
    }

    private void DoneReloading()
    {
        var gun = weaponManager.WeaponComponent as GunWeapon;
        if(gun != null)
        {
            gun.Reload();
        }
    }

    private void GetClips()
    {
        foreach(var clip in animController.runtimeAnimatorController.animationClips)
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