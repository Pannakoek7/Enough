using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Slide : ParentInteraction
{
    
    [SerializeField] protected bool horizontal;

    [SerializeField] protected float minLength;
    [SerializeField] protected float maxLength;

    protected virtual void Update()
    {
        if(active == true)
        {
            UnityEngine.Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(horizontal == true)
            {
                gameObject.transform.position = new UnityEngine.Vector2(Mathf.Clamp(newPosition.x, minLength, maxLength), gameObject.transform.position.y);
            }
            else
            {
                //Maybe I can calculate and integrate the offset to let it be more smooth
                gameObject.transform.position = new UnityEngine.Vector2(gameObject.transform.position.x, Mathf.Clamp(newPosition.y, minLength, maxLength));
            }
        }
    }

    
}
