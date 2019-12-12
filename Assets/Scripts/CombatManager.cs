using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private static readonly string RELOAD_TRIGGER = "Reload";
    private static readonly string RELOAD_SPEED = "ReloadSpeed";
    private static readonly string DEATH_ANIMATION_TYPE = "RandomDeath";
    private static readonly string DEATH_ANIMAIONS = "DeathAnimations";
    private static readonly string AIMING_TRIGGER = "Aiming";
    private static readonly float DESTROY_DELAY_SECONDS = 5f;

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
    private AnimationClip reloadAnimation;
    private AnimationClip shootAnimation;
    private float originalZoom;
    private float zoomTimer;

    public float Health
    {
        get { return health * (1 + HealthExtraPercentage); }
        set { health = value * (1 + DamageReductionPercentage); }
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
            if(reloadAnimation != null && shootAnimation != null)
            {
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            if(agent != null)
            {
                GetComponent<AIControl>().target = null;
                agent.speed = 0;
                agent = null;
            }
            animController.SetTrigger(DEATH_TRIGGER);
            var deathAnimation = Random.Range(1, animController.GetInteger(DEATH_ANIMAIONS) + 1);
            animController.SetInteger(DEATH_ANIMATION_TYPE, deathAnimation);
            Destroy(gameObject, DESTROY_DELAY_SECONDS);
        }
        else
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
            animController.SetFloat(SHOOT_SPEED, shootAnimation.length / gun.TimeBetweenShots);
        }
        animController.SetTrigger(SHOOT_TRIGGER);
        weaponManager.WeaponComponent.Attack();
    }

    private void DoneReloading()
    {
        ((GunWeapon) weaponManager.WeaponComponent).Reload();
    }
}