using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterControl))]
public class PlayerControl : MonoBehaviour
{
    public float timeToFullSpeed = 0.5f;

    private CharacterControl character;
    private float currentTimeToFullSpeed;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterControl>();
        currentTimeToFullSpeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var shift = Input.GetAxis("LeftShift");
        var rightClick = Input.GetAxis("Fire2");
        currentTimeToFullSpeed += Time.deltaTime;
        if(currentTimeToFullSpeed > timeToFullSpeed)
        {
            currentTimeToFullSpeed = timeToFullSpeed;
        }

        var newSpeed = character.OriginalSpeed * (currentTimeToFullSpeed / timeToFullSpeed);


        if(shift > 0 || rightClick > 0)
        {
            newSpeed /= 2f;
        }
        else if(h != 0 && v != 0)
        {
            newSpeed /= 2f;
        }
        else if(h != 0 || v < 0)
        {
            newSpeed /= 1.2f;
        }

        character.Speed = newSpeed;

        var verticalMovement = transform.forward * System.Math.Sign(v);
        var horizontalMovement = transform.right * System.Math.Sign(h);

        character.Move(verticalMovement + horizontalMovement);
        var lookAtPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));

        character.LookAtRotate(lookAtPosition);

        if(v == 0 && h == 0)
        {
            currentTimeToFullSpeed = 0;
        }
    }
}
