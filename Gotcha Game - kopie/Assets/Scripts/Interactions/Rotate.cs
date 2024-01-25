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
    }

    float offsetAngle;
    float offsetAngleTwo;
    float theta_radians;

    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        CalculateAngle();
        offsetAngle = theta_radians;
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        offsetAngleTwo = theta_radians;
    }

    void CalculateAngle()
    {
        UnityEngine.Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var delta_x = newPosition.x - centerPosition.x;
        var delta_y = newPosition.y - centerPosition.y;
        theta_radians = Mathf.Atan2(delta_y, delta_x) * (180/MathF.PI);
    }

    void Update()
    {
        if(active == true)
        {
            CalculateAngle();
            //Dont ask me why this works lmao
            theta_radians -= offsetAngle;
            theta_radians -= offsetAngleTwo * -1;
           
            gameObject.transform.rotation = Quaternion.Euler(0,0,theta_radians); 
        }
    }

}
