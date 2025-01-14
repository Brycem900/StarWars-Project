﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class CharacterControl : MonoBehaviour
{
    private static readonly string HIP_BONE = "mixamorig:Hips";
    private static readonly string ANIMATOR_FORWARD = "Forward";
    private static readonly string ANIMATOR_RIGHT = "Right";

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float turnSpeed = 5f;

    private float originalSpeed;
    private Rigidbody rbody;
    private Animator animator;
    private float horizontalSpeed;
    private float verticalSpeed;
    private bool forceStop;
    private Dictionary<string, Transform> bones;

    public Dictionary<string, Transform> Bones
    {
        get { return bones; }
    }

    public bool ForceStop
    {
        get { return forceStop; }
        set { forceStop = value; }
    }

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

    void Awake()
    {
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        originalSpeed = speed;
        horizontalSpeed = 0f;
        verticalSpeed = 0f;
        forceStop = false;
        bones = new Dictionary<string, Transform>();
        AddBone(transform.Find(HIP_BONE));
    }

    private void AddBone(Transform bone)
    {
        if(bone.name.Contains("mixamorig:"))
        {
            var name = bone.name.Substring(bone.name.LastIndexOf('/') + 1).Replace("mixamorig:", "");
            bones[name] = bone;
            foreach(Transform child in bone)
            {
                AddBone(child);
            }
        }
    }

    void FixedUpdate()
    {
        horizontalSpeed -= System.Math.Sign(horizontalSpeed) * Time.fixedDeltaTime * (float) System.Math.PI;
        verticalSpeed -= System.Math.Sign(verticalSpeed) * Time.fixedDeltaTime * (float) System.Math.PI;
        if(System.Math.Abs(horizontalSpeed) < 0.05)
        {
            horizontalSpeed = 0;
        }
        if(System.Math.Abs(verticalSpeed) < 0.05)
        {
            verticalSpeed = 0;
        }
    }

    public void Move(Vector3 moveVector)
    {
        if(!forceStop)
        {
            var newPosition = transform.position + (moveVector * Speed);
            var direction = -transform.InverseTransformDirection(transform.position - newPosition);
            var realForward = direction.z;
            var realRight = direction.x;
            verticalSpeed += realForward + ( System.Math.Sign(realForward) * Time.deltaTime);
            horizontalSpeed += realRight + ( System.Math.Sign(realRight) * Time.deltaTime);

            if(System.Math.Abs(verticalSpeed) > 1)
            {
                verticalSpeed = System.Math.Sign(verticalSpeed);
            }
            if(System.Math.Abs(horizontalSpeed) > 1)
            {
                horizontalSpeed = System.Math.Sign(horizontalSpeed);
            }

            animator.SetFloat(ANIMATOR_FORWARD, verticalSpeed * (Speed / OriginalSpeed));
            animator.SetFloat(ANIMATOR_RIGHT, horizontalSpeed * (Speed / OriginalSpeed));
            rbody.MovePosition(newPosition);
        }
    }

    public void LookAtRotate(Vector3 location, bool flipY=false, float xAmount=0)
    {
        LookAtRotateObject(transform, location, flipY, xAmount);
    }

    public void LookAtRotateObject(Transform obj, Vector3 location, bool flipY=false, float xAmount = 0)
    {
        if(!forceStop)
        {
            var lookPos = location - obj.position;
            var rotation = Quaternion.LookRotation(lookPos);
            var euler = rotation.eulerAngles;
            euler.x = xAmount;
            if(flipY)
            {
                euler.y += 180;
            }
            rotation.eulerAngles = euler;
            obj.rotation = Quaternion.Slerp(obj.rotation, rotation, turnSpeed);
        }
    }
}
