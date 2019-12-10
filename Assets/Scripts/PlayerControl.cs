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
    void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var shift = Input.GetAxis("LeftShift");
        var rightClick = Input.GetAxis("Fire2");
        var newSpeed = character.OriginalSpeed;

        if(shift > 0 || rightClick > 0)
        {
            newSpeed = character.OriginalSpeed / 2;
        }

        if(h != 0 || v < 0)
        {
            newSpeed = character.OriginalSpeed / 2;
        }

        character.Speed = newSpeed;

        var verticalMovement = transform.forward * System.Math.Sign(v);
        var horizontalMovement = transform.right * System.Math.Sign(h);

        character.Move(verticalMovement + horizontalMovement);
        var lookAtPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));

        character.LookAtRotate(lookAtPosition);
    }
}
