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

    void Start()
    {
        weaponScript = transform.Find("Weapon").gameObject.GetComponent<Weapon>();
    }

    override public void Attack()
    {

    }

    override public bool CanAttack()
    {
        return true;
    }

    public void ToggleWeaponOnOff()
    {
        weaponScript.ToggleWeaponOnOff();
    }

    public void ChangeColor(Color c)
    {
        if(weaponScript == null)
        {
            weaponScript = transform.Find("Weapon").gameObject.GetComponent<Weapon>();
        }
        weaponScript.bladeColor = c;
    }
}
