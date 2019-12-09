using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(WeaponManager))]
public class CombatManager : MonoBehaviour
{
    public Text healthText;

    private static readonly string HEALTH_PARAMETER = "Health";
    private static readonly string DEATH_TRIGGER = "Death";
    private static readonly string DEATH_ANIMATION_TYPE = "RandomDeath";
    private static readonly string DEATH_ANIMAIONS = "DeathAnimations";
    private static readonly float DESTROY_DELAY_SECONDS = 5f;
    private static readonly int GENERIC_DEATH_ANIMATIONS = 1;
    private static readonly int RIFLE_DEATH_ANIMATIONS = 2 + GENERIC_DEATH_ANIMATIONS;
    private static readonly int PISTOL_DEATH_ANIMATIONS = 0 + GENERIC_DEATH_ANIMATIONS;
    private static readonly int LIGHTSABER_DEATH_ANIMAIONS = 0 + GENERIC_DEATH_ANIMATIONS;
    private float health;
    private float damageReductionPercentage;
    private float damageExtraPercentage;
    private float speedExtraPercentage;
    private float healthExtraPercentage;
    private bool isPlayer;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animController;
    private WeaponManager weaponManager;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlayer)
        {
            health -= 1;
        }
        if(healthText != null)
        {
            healthText.text = Health.ToString();
        }
        if(Health <= 0)
        {
            if(agent != null)
            {
                GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = null;
                agent.speed = 0;
                agent = null;
            }
            animController.SetTrigger(DEATH_TRIGGER);
            int deathAnimation = Random.Range(1, animController.GetInteger(DEATH_ANIMAIONS) + 1);
            animController.SetInteger(DEATH_ANIMATION_TYPE, deathAnimation);
            Destroy(gameObject, DESTROY_DELAY_SECONDS);
        }

        if(agent != null)
        {
            agent.speed = agent.speed * (1 + SpeedExtraPercentage);
        }
    }
}