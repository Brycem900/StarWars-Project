using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsaberBlade : MonoBehaviour
{
    private GameObject owner;
    private bool enabled;
    private float minDamage;
    private float maxDamage;

    public GameObject Owner
    {
        get { return owner; }
        set { owner = value; }
    }

    public bool Enabled
    {
        get { return enabled; }
        set { enabled = value; }
    }

    public float MinDamage
    {
        get { return minDamage; }
        set { minDamage = value; }
    }

    public float MaxDamage
    {
        get { return maxDamage; }
        set { maxDamage = value; }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(enabled && collision.gameObject != Owner)
        {
            var otherCombat = collision.gameObject.GetComponent<CombatManager>();
            var thisCombat = Owner.GetComponent<CombatManager>();
            if(otherCombat != null)
            {
                otherCombat.Health -= Random.Range(MinDamage, MaxDamage) * (1 + thisCombat.DamageExtraPercentage) / (1 + otherCombat.DamageReductionPercentage);
            }
        }
    }
}
