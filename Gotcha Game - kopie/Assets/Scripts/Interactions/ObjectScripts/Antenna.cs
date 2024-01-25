using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : Slide
{

    UnityEngine.Vector2 startPosition;
    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected override void Update()
    {
        if(active == true)
        {
            UnityEngine.Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(horizontal == true)
            {
                gameObject.transform.parent.transform.localScale = new UnityEngine.Vector2(Mathf.Clamp(newPosition.x, minLength, maxLength), gameObject.transform.parent.transform.localScale.y);
            }
            else
            {
                //this works for some godforsaken reason
                var yessir = Mathf.Abs((newPosition.y - startPosition.y) * .67f + minLength);
                //Mathf.Clamp(yessir, minLength, maxLength);
                gameObject.transform.parent.transform.localScale = new UnityEngine.Vector2(gameObject.transform.parent.transform.localScale.x, Mathf.Clamp(yessir, minLength, maxLength));
            }
        }

        if(gameObject.transform.parent.transform.localScale.y == maxLength)
        {
            if(bCol.myState == BoolCollection.State.Magneticwaves)
            {
                tHandler.ProgressText(radioChapter.Appointment, radio, 0, protaginist);
                bCol.myState = BoolCollection.State.RadioWorking;
            } 
            else if(bCol.myState == BoolCollection.State.BrokenRadio) 
            {
                
                tHandler.ProgressText(radioChapter.Static, radio, 0, protaginist);
                bCol.myState = BoolCollection.State.Receive;
            }

        }
    }
}
