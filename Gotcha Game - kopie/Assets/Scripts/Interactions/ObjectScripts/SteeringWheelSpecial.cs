using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelSpecial : Drag
{

    LayerMask lm;

    protected override void Start()
    {
        base.Start();
        lm = LayerMask.GetMask("Special");
    }
    protected override void Update()
    {
        base.Update();

        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.localPosition, Vector2.zero, 1, lm);
        Debug.DrawRay(this.transform.localPosition, Vector2.right * 3, Color.green, 10, false);
        if(hit)
        {
            print(hit.collider.gameObject.name);
        }
        
        if(hit && hit.collider.gameObject.name == "Frame")
        {
            Debug.Log("Yippie :(");
            
            gameObject.transform.localPosition = new Vector3(-3.88f, -2.45f, 0);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(6.5f, 6.5f);

            gameObject.GetComponentInChildren<SteeringWheel>(true).enabled = true;
            this.enabled = false;
        }
    }    

    protected override void OnMouseDown() 
    {
        if(enabled == true)
        {
            base.OnMouseDown();
        }
    }
}
