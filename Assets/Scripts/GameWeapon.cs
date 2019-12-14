using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class GameWeapon : MonoBehaviour
{
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
                var characterComponent = owner.GetComponent<CharacterControl>();
                ownerHand = characterComponent.Bones["RightHand"].gameObject;
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
