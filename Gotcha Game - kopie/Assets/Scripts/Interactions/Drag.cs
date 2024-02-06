using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;


public class Drag : ParentInteraction
{
    //Dragging mechanic
    protected virtual void Update()
    {   
        if(active == true)
        {
            UnityEngine.Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = newPosition;
        }
    }
}
