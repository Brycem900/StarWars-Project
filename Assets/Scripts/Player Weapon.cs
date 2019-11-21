using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon
{
    private GameObject weapon;
    private float durability;

    public GameObject Weapon
    {
        get { return weapon; }
        set { weapon = value; }
    }

    public float Durability
    {
        get { return durability; }
        set { durability = value; }
    }

    public PlayerWeapon(GameObject weapon, float durability)
    {
        this.weapon = weapon;
        this.durability = durability;
    }
}
