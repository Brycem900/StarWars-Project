using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var h = CrossPlatformInputManager.GetAxis("Horizontal");
        var v = CrossPlatformInputManager.GetAxis("Vertical");
        var shift = CrossPlatformInputManager.GetAxis("LeftShift");

        var newPosition = transform.position;
        var newSpeed = speed;

        if(shift > 0)
        {
            newSpeed /= 2;
        }

        if(h > 0)
        {
            newPosition += h*transform.forward * newSpeed * Time.smoothDeltaTime;
        }
        else if(h < 0)
        {
            newPosition -= h*transform.forward * newSpeed * Time.smoothDeltaTime;
        }
        else if(v > 0)
        {
            newPosition += v*transform.forward * newSpeed * Time.smoothDeltaTime;
        }
        else if(v < 0)
        {
            newPosition -= v*transform.forward * newSpeed * Time.smoothDeltaTime;
        }

        m_Rigidbody.MovePosition(newPosition);

        // transform.position = Vector3.Lerp(transform.position, newPosition, Time.smoothDeltaTime);
    }
}
