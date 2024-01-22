using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotate : ParentInteraction
{

    UnityEngine.Vector3 centerPosition;

    protected override void Start()
    {
        base.Start();
        centerPosition = gameObject.transform.position;

        print("TWO");
    }

    Quaternion pain;

    void Update()
    {
        if(active == true)
        {
            UnityEngine.Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var delta_x = newPosition.x - centerPosition.x;
            var delta_y = newPosition.y - centerPosition.y;
            var theta_radians = Mathf.Atan2(delta_y, delta_x) * (180/MathF.PI);

            gameObject.transform.rotation = Quaternion.Euler(0,0,theta_radians); 
        }
    }

}
