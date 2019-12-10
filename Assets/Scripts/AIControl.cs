using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterControl))]
[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
public class AIControl : MonoBehaviour
{
    private CharacterControl character;
    private UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterControl>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
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
}
