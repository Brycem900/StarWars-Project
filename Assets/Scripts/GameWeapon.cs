using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class GameWeapon : MonoBehaviour
{
    private static readonly string OWNER_HAND = "mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/mixamorig:RightHandIndex1";

    private float durability = 0f;
    private GameObject owner;
    private GameObject ownerHand;

    public float Durability
    {
        get { return durability; }
        set { durability = value; }
    }

    public GameObject Owner
    {
        get { return owner; }
        set
        {
            owner = value;
            if(owner != null)
            {
                ownerHand = owner.transform.Find(OWNER_HAND).gameObject;
            }
        }
    }

    public GameObject OwnerHand
    {
        get { return ownerHand; }
    }

    abstract public void Attack();

    abstract public bool CanAttack();
}
