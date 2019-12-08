﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WeaponManager : MonoBehaviour
{
    private static KeyCode TOGGLE_KEY_CODE = KeyCode.E;

    public GameObject lightsaber;
    public GameObject pistol;
    public GameObject rifle;

    private System.Random random;
    private GameObject rightHand;
    private GameWeapon currentWeapon;
    private Animator currentAnimator;
    private UnityEngine.AI.NavMeshAgent currentAgent;
    private WeaponSettings lightsaberSettings;
    private WeaponSettings pistolSettings;
    private WeaponSettings rifleSettings;

    public GameWeapon CurrentWeapon
    {
        get; set;
    }

    // Start is called before the first frame update
    void Start()
    {
        rightHand = transform.Find(WeaponSettings.RIGHT_HAND).gameObject;
        currentAnimator = GetComponent<Animator>();
        currentAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        try
        {
            lightsaberSettings = WeaponSettings.LIGHTSABER_MAPPINGS[gameObject.tag];
        }
        catch(KeyNotFoundException e)
        {
            lightsaberSettings = null;
        }
        try
        {
            rifleSettings = WeaponSettings.RIFLE_MAPPINGS[gameObject.tag];
        }
        catch(KeyNotFoundException e)
        {
            rifleSettings = null;
        }
        try
        {
            pistolSettings = WeaponSettings.PISTOL_MAPPINGS[gameObject.tag];
        }
        catch(KeyNotFoundException e)
        {
            pistolSettings = null;
        }

        random = new System.Random();
        var choice = random.NextDouble();

        // Choose a random weapon, or choose a different weapon immediately if this character does not have a mapping
        // for the random weapon
        if(choice >= WeaponSettings.PISTOL_WEAPON_CHANCE || (pistolSettings != null && rifleSettings == null && lightsaberSettings == null))
        {
            EquipPistol(1f);
        }
        else if(choice >= WeaponSettings.RIFLE_WEAPON_CHANCE || (rifleSettings != null && lightsaberSettings == null))
        {
            EquipRifle(1f);
        }
        else if(lightsaberSettings != null)
        {
            EquipLightsaber(1f);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(TOGGLE_KEY_CODE) && WeaponSettings.isPlayer(gameObject.tag))
        {
            if(currentWeapon != null && currentWeapon.Weapon != null && WeaponSettings.isLightsaber(currentWeapon.Weapon.tag))
            {
                getLightsaberWeaponObject().GetComponent<Weapon>().ToggleWeaponOnOff();
            }
        }
    }

    public void EquipPistol(float durability)
    {
        if(currentAgent != null)
        {
            currentAgent.stoppingDistance = pistolSettings.navAgentDistance;
        }
        createWeapon(pistol, durability, pistolSettings.position, pistolSettings.rotation, pistolSettings.scale, pistolSettings.controllerPath);
    }

    public void EquipRifle(float durability)
    {
        if(currentAgent != null)
        {
            currentAgent.stoppingDistance = rifleSettings.navAgentDistance;
        }
        createWeapon(rifle, durability, rifleSettings.position, rifleSettings.rotation, rifleSettings.scale, rifleSettings.controllerPath);
    }

    public void EquipLightsaber(float durability)
    {
        if(currentAgent != null)
        {
            currentAgent.stoppingDistance = lightsaberSettings.navAgentDistance;
        }
        createWeapon(lightsaber, durability, lightsaberSettings.position, lightsaberSettings.rotation, lightsaberSettings.scale, lightsaberSettings.controllerPath);

        var lightsaberObject = getLightsaberWeaponObject();

        if(WeaponSettings.isHood(gameObject.tag))
        {
            lightsaberObject.GetComponent<Weapon>().bladeColor = WeaponSettings.HOOD_LIGHTSABER_COLOR;
        }
        else if(WeaponSettings.isEthan(gameObject.tag))
        {
            lightsaberObject.GetComponent<Weapon>().bladeColor = WeaponSettings.ETHAN_LIGHTSABER_COLOR;
        }
        else if(WeaponSettings.isStormtrooper(gameObject.tag))
        {
            lightsaberObject.GetComponent<Weapon>().bladeColor = WeaponSettings.STORMTROOPER_LIGHTSABER_COLOR;
        }
        else if(WeaponSettings.isAlien(gameObject.tag))
        {
            lightsaberObject.GetComponent<Weapon>().bladeColor = WeaponSettings.ALIEN_LIGHTSABER_COLOR;
        }

        if(!WeaponSettings.isPlayer(gameObject.tag))
        {
            lightsaberObject.GetComponent<Weapon>().ToggleWeaponOnOff();
        }
    }

    private void createWeapon(GameObject weapon, float durability, Vector3 position, Quaternion rotation, Vector3 scale, string c)
    {
        var clone = Instantiate<GameObject>(weapon);
        clone.transform.parent = rightHand.transform;
        clone.transform.localPosition = position;
        clone.transform.localRotation = rotation;
        clone.transform.localScale = scale;

        currentAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(c);
        currentWeapon = new GameWeapon(clone, durability);
    }

    private GameObject getLightsaberWeaponObject()
    {
        return currentWeapon.Weapon.transform.Find("Weapon").gameObject;
    }
}