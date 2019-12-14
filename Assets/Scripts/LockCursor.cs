using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCursor : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Awake()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.visible = true;
        }
    }

    void OnGUI()
    {
        var mousePos = Event.current.mousePosition;

        mousePos.x = Mathf.Clamp(mousePos.x, minX, maxX);
        mousePos.y = Mathf.Clamp(mousePos.y, minY, maxY);
    }
}
