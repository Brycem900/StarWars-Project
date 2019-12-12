using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsaberWeapon : GameWeapon
{
    [SerializeField]
    private float maxDamage = 0f;

    [SerializeField]
    private float minDamage = 0f;

    [SerializeField]
    private float timeBetweenSwings = 0f;

    private Weapon weaponScript = null;
    private GameObject bladeObject;
    private LightsaberBlade bladeScript;
    private float untilCanAttack;

    public float TimeBetweenSwings
    {
        get { return timeBetweenSwings; }
        set { timeBetweenSwings = value; }
    }

    void Start()
    {
        weaponScript = GetWeaponComponent();
        bladeObject = GetBladeObject();
        bladeScript = bladeObject.GetComponent<LightsaberBlade>();
        bladeScript.Owner = Owner;
        untilCanAttack = Time.time;
    }

    override public void Attack()
    {
        if(bladeScript == null)
        {
            if(bladeObject == null)
            {
                bladeObject = GetBladeObject();
            }

            bladeScript = bladeObject.GetComponent<LightsaberBlade>();
        }
        bladeScript.MinDamage = minDamage;
        bladeScript.MaxDamage = maxDamage;
        bladeScript.Enabled = true;
        untilCanAttack = Time.time + timeBetweenSwings;
        weaponScript.PlaySwingSound();
    }

    override public bool CanAttack()
    {
        return !OnCooldown();
    }

    public bool OnCooldown()
    {
        return untilCanAttack >= Time.time;
    }

    public void ToggleWeaponOnOff()
    {
        weaponScript.ToggleWeaponOnOff();
    }

    public void ChangeColor(Color c)
    {
        if(weaponScript == null)
        {
            weaponScript = GetWeaponComponent();
        }
        weaponScript.bladeColor = c;
    }

    public void DoneAttack()
    {
        bladeScript.Enabled = false;
    }

    private Weapon GetWeaponComponent()
    {
        return transform.Find("Weapon").gameObject.GetComponent<Weapon>();
    }

    private GameObject GetBladeObject()
    {
        return transform.Find("Weapon/Blade").gameObject;
    }

}
