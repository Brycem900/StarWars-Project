using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCursor : MonoBehaviour
{
    void OnMouseDown()
    {
        // Lock the cursor
        Screen.lockCursor = true;
    }

    void Start()
    {
        Screen.lockCursor = true;
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
            Screen.lockCursor = false;
    }
}
