using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControl))]
[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
public class AIControl : MonoBehaviour
{
    public Transform target;

    private CharacterControl character;
    private UnityEngine.AI.NavMeshAgent agent;

    public UnityEngine.AI.NavMeshAgent Agent
    {
        get { return agent; }
    }

    public CharacterControl Character
    {
        get { return character; }
    }

    void Start()
    {
        character = GetComponent<CharacterControl>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
            if(!IsFacingTarget())
            {
                character.LookAtRotate(target.position);
            }
        }

        if(agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity);
        }
        else
        {
            character.Move(Vector3.zero);
        }
    }

    public bool IsFacingTarget()
    {
        return Vector3.Dot(agent.destination - transform.position, transform.forward) > 0;
    }
}
