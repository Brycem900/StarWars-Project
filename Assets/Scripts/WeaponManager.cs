using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.Linq;

[RequireComponent(typeof(Animator))]
public class WeaponManager : MonoBehaviour
{
    public bool isPlayer;
    public List<GameObject> weaponTypes;
    public List<float> weaponSpawnRates;

    private System.Random random;
    private GameObject rightHand;
    private GameObject currentWeapon;
    private GameWeapon weaponComponent;
    private Animator currentAnimator;
    private UnityEngine.AI.NavMeshAgent currentAgent;
    private Color lightsaberColor;

    public GameObject CurrentWeapon
    {
        get { return currentWeapon; }
        set { currentWeapon = value; }
    }

    public GameWeapon WeaponComponent
    {
        get { return weaponComponent; }
        set { weaponComponent = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Assert.AreEqual(weaponTypes.Count, weaponSpawnRates.Count);
        Assert.IsTrue(weaponSpawnRates.All(x => x>= 0));
        Assert.AreApproximatelyEqual(weaponSpawnRates.Sum(), 1, Mathf.Epsilon);

        var ordered = weaponSpawnRates.OrderBy(x => x);
        Assert.IsTrue(weaponSpawnRates.SequenceEqual(ordered));

        rightHand = transform.Find(WeaponSettings.RIGHT_HAND).gameObject;
        currentAnimator = GetComponent<Animator>();
        currentAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        try
        {
            lightsaberColor = WeaponSettings.LIGHTSABER_COLOR_MAPPINGS[gameObject.tag];
        }
        catch(KeyNotFoundException e)
        {
        }

        random = new System.Random();

        EquipWeapon(PickWeapon(), 1f);
    }

    private GameObject PickWeapon()
    {
        var roll = random.NextDouble();
        var cumulative = 0.0;
        for(var i = 0; i < weaponTypes.Count; i++)
        {
            cumulative += weaponSpawnRates[i];
            if(roll < cumulative)
            {
                return weaponTypes[i];
            }
        }

        return weaponTypes[weaponTypes.Count - 1];
    }

    public void EquipWeapon(GameObject weapon, float durability)
    {
        var weaponSettings = WeaponSettings.WEAPON_MAPPINGS[new System.Tuple<string, string>(gameObject.tag, weapon.tag)];
        if(currentAgent != null)
        {
            currentAgent.stoppingDistance = weaponSettings.navAgentDistance;
        }

        if(currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        currentWeapon = Instantiate<GameObject>(weapon);
        weaponComponent = currentWeapon.GetComponent<GameWeapon>();
        weaponComponent.Owner = gameObject;
        weaponComponent.Durability = durability;
        currentWeapon.transform.parent = rightHand.transform;
        currentWeapon.transform.localPosition = weaponSettings.position;
        currentWeapon.transform.localRotation = weaponSettings.rotation;
        currentWeapon.transform.localScale = weaponSettings.scale;
        currentAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(weaponSettings.controllerPath);

        if(WeaponSettings.IsLightsaber(weapon.tag))
        {
            var lightsaberComponent = (LightsaberWeapon) weaponComponent;
            lightsaberComponent.ChangeColor(lightsaberColor);

            if(!isPlayer)
            {
                lightsaberComponent.ToggleWeaponOnOff();
            }
        }
    }
}
