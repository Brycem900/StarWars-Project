using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float damage;

    [SerializeField]
    private float maxDistance;

    private GameObject owner;
    private float currentDistance;

    public float Speed
    {
        get{ return speed; } set{ speed = value; }
    }

    public float Damage
    {
        get{ return damage; } set{ damage = value; }
    }

    public GameObject Owner
    {
        get{ return owner; } set{ owner = value; }
    }

    public float MaxDistance
    {
        get{ return maxDistance; } set{ maxDistance = value;}
    }

    void Start()
    {
        currentDistance = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var distance = Vector3.forward * Time.fixedDeltaTime * speed;
        currentDistance += distance.x + distance.y + distance.z;
        if(currentDistance >= maxDistance)
        {
            Destroy(gameObject);
        }
        transform.Translate(distance);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other != owner.GetComponent<CapsuleCollider>())
        {
            var otherCombat = other.GetComponent<CombatManager>();
            var thisCombat = owner.GetComponent<CombatManager>();
            if(otherCombat != null)
            {
                otherCombat.Health -= damage * (1 + thisCombat.DamageExtraPercentage) / (1 + otherCombat.DamageReductionPercentage);
            }

            Destroy(gameObject);
        }
    }
}
