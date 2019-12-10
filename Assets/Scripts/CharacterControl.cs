using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class CharacterControl : MonoBehaviour
{
    private static readonly string ANIMATOR_FORWARD = "Forward";
    private static readonly string ANIMATOR_RIGHT = "Right";

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float turnSpeed = 5f;

    private float originalSpeed;
    private Rigidbody rbody;
    private Animator animator;

    public float OriginalSpeed
    {
        get{ return originalSpeed; }
    }

    public float Speed
    {
        get{ return speed; } set{ speed = value; }
    }

    public float TurnSpeed
    {
        get{ return turnSpeed; } set{ turnSpeed = value; }
    }

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        originalSpeed = speed;
    }

    public void Move(Vector3 moveVector)
    {
        var newPosition = transform.position + (moveVector * Speed * Time.fixedDeltaTime);
        var direction = -transform.InverseTransformDirection(transform.position - newPosition);
        var realForward = direction.z;
        var realRight = direction.x;
        if(System.Math.Abs(realForward) < 0.01)
        {
            realForward = 0;
        }
        if(System.Math.Abs(realRight) < 0.01)
        {
            realRight = 0;
        }
        animator.SetFloat(ANIMATOR_FORWARD, System.Math.Sign(realForward) * (Speed / OriginalSpeed));
        animator.SetFloat(ANIMATOR_RIGHT, System.Math.Sign(realRight) * (Speed / OriginalSpeed));
        rbody.MovePosition(newPosition);
    }

    public void LookAtRotate(Vector3 location)
    {
        var lookPos = location - transform.position;
        var rotation = Quaternion.LookRotation(lookPos);
        var euler = rotation.eulerAngles;
        euler.x = 0;
        euler.y += 180;
        rotation.eulerAngles = euler;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.fixedDeltaTime * turnSpeed);
    }
}
