using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(WeaponManager))]
public class CombatManager : MonoBehaviour
{
    public Text healthText;
    public float timeToZoomIn;
    public float zoomInAmount;
    public GameObject rifleBullet;
    public GameObject pistolBullet;

    private static readonly string HAND = "mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/mixamorig:RightHandIndex1";
    private static readonly string HEALTH_PARAMETER = "Health";
    private static readonly string DEATH_TRIGGER = "Death";
    private static readonly string DEATH_ANIMATION_TYPE = "RandomDeath";
    private static readonly string DEATH_ANIMAIONS = "DeathAnimations";
    private static readonly string AIMING_TRIGGER = "Aiming";
    private static readonly float DESTROY_DELAY_SECONDS = 5f;

    private float health;
    private float damageReductionPercentage;
    private float damageExtraPercentage;
    private float speedExtraPercentage;
    private float healthExtraPercentage;
    private bool isPlayer;
    private bool aiming;
    private float lastLeftClick;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animController;
    private WeaponManager weaponManager;
    private float originalZoom;
    private float zoomTimer;
    private GameObject hand;

    public float Health
    {
        get{ return health * (1 + HealthExtraPercentage); } set { health = value * (1 + DamageReductionPercentage); }
    }

    public float DamageReductionPercentage
    {
        get; set;
    }

    public float DamageExtraPercentage
    {
        get; set;
    }

    public float SpeedExtraPercentage
    {
        get; set;
    }

    public float HealthExtraPercentage
    {
        get; set;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        damageReductionPercentage = 0f;
        damageReductionPercentage = 0f;
        speedExtraPercentage = 0f;
        healthExtraPercentage = 0f;

        isPlayer = WeaponSettings.IsPlayer(gameObject.tag);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animController = GetComponent<Animator>();
        weaponManager = GetComponent<WeaponManager>();
        aiming = false;
        originalZoom = Camera.main.fieldOfView;
        zoomTimer = timeToZoomIn;
        lastLeftClick = 0;
        hand = gameObject.transform.Find(HAND).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthText != null)
        {
            healthText.text = Health.ToString();
        }
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

        if(agent != null)
        {
            agent.speed = agent.speed * (1 + SpeedExtraPercentage);
        }
    }

    void FixedUpdate()
    {
        var rightClick = Input.GetAxis("Fire2");
        var leftClick = Input.GetAxis("Fire1");
        if(WeaponSettings.IsPlayer(gameObject.tag))
        {
            if(!aiming && rightClick != 0
            || aiming && rightClick == 0)
            {
                ToggleAiming();
            }

            if(zoomTimer < timeToZoomIn)
            {
                var zoom = aiming ? -1 : 1;
                Camera.main.fieldOfView += (zoomInAmount * zoom) * Time.fixedDeltaTime;
                zoomTimer += Time.fixedDeltaTime;
            }

            if((leftClick > 0 && lastLeftClick == 0) && aiming)
            {
                Attack();
            }

            lastLeftClick = leftClick;
        }
    }

    public void ToggleAiming()
    {
        animController.SetTrigger(AIMING_TRIGGER);
        aiming = !aiming;
        zoomTimer = 0;
        if(WeaponSettings.IsLightsaber(weaponManager.CurrentWeapon.Weapon.tag))
        {
            weaponManager.CurrentWeapon.Weapon.transform.Find("Weapon").gameObject.GetComponent<Weapon>().ToggleWeaponOnOff();
        }
    }

    public void Attack()
    {
        GameObject bullet = null;
        if(WeaponSettings.IsRifle(weaponManager.CurrentWeapon.Weapon.tag))
        {
            bullet = rifleBullet;
        }
        else if(WeaponSettings.IsPistol(weaponManager.CurrentWeapon.Weapon.tag))
        {
            bullet = pistolBullet;
        }
        
        if(bullet != null)
        {
            var realBullet = Instantiate<GameObject>(bullet, hand.transform.position, transform.rotation);
            realBullet.GetComponent<Bullet>().Owner = gameObject;
        }
    }
}