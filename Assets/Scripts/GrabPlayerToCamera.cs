using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPlayerToCamera : MonoBehaviour
{
    void Awake()
    {
        GetComponent<UnityStandardAssets.Cameras.AutoCam>().SetTarget(GameObject.Find("Player").transform);
    }
}
