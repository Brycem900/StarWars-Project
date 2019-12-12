using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterControl))]
public class PlayerControl : MonoBehaviour
{
    private CharacterControl character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterControl>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var shift = Input.GetAxis("LeftShift");
        var rightClick = Input.GetAxis("Fire2");

        var newSpeed = character.OriginalSpeed;

        if(shift > 0 || rightClick > 0)
        {
            newSpeed /= 1.5f;
        }
        else if(h != 0 && v != 0)
        {
            newSpeed /= 1.2f;
        }
        else if(h != 0 || v < 0)
        {
            newSpeed /= 1.2f;
        }

        character.Speed = newSpeed;

        var verticalMovement = transform.forward * System.Math.Sign(v) * Time.deltaTime;
        var horizontalMovement = transform.right * System.Math.Sign(h) * Time.deltaTime;

        character.Move(verticalMovement + horizontalMovement);
        var lookAtPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));

        character.LookAtRotate(lookAtPosition);
    }
}
