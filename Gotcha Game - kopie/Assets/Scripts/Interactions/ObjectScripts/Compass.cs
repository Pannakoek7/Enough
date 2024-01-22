using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Compass : Drag
{
    UnityEngine.Vector2 finalDestination;
    protected override void Start()
    {
        base.Start();

        finalDestination = new UnityEngine.Vector2(-5, -3);
        
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        gameObject.transform.rotation = Quaternion.Euler(0,0,270);
    }

    protected override void Update()
    {
        if(active == true)
        {
            UnityEngine.Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = newPosition;
            
            var delta_x = newPosition.x - finalDestination.x;
            var delta_y = newPosition.y - finalDestination.y;
            var theta_radians = Mathf.Atan2(delta_y, delta_x) * (180/MathF.PI);

            gameObject.transform.rotation = Quaternion.Euler(0,0,theta_radians);

            //offset of .1 to get it correct.
            if(gameObject.transform.position.x > finalDestination.x - .1f && gameObject.transform.position.x < finalDestination.x + .1f)
            {
                if(gameObject.transform.position.y > finalDestination.y - .1f && gameObject.transform.position.y < finalDestination.y + .1f)
                {
                    var c = gameObject.GetComponent<SpriteRenderer>();
                    c.color = Color.magenta;
                }
            }
        }
    }
}
