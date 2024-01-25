using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : Rotate
{
    myDelegate wheelEvent;
    //it shows different in editor, but in code it uses 360 going to the left first.
    int[] angleCoords = {135, 280, 45};
    int progressIndex;

    protected override void Start()
    {
        //Add function to event
        //Lambda function to pass parameters
        base.Start();

        wheelEvent += checkAngle;
    }

    IEnumerator CheckForConfirmation()
    {
        yield return new WaitForSeconds(1f);
        if(transform.rotation.eulerAngles.z < angleCoords[progressIndex] + 8 && transform.rotation.eulerAngles.z > angleCoords[progressIndex] - 8)
        {
            progressIndex += 1;
            print(progressIndex);
            //make lights go green
        } 

        if(progressIndex == angleCoords.Length)
        {
            wheelEvent -= checkAngle;
            print("beep beep Im a sheep");
            //and progress the story
        } else {
            wheelEvent += checkAngle;
        }
    }

    void checkAngle()
    {
        if(transform.rotation.eulerAngles.z < angleCoords[progressIndex] + 8 && transform.rotation.eulerAngles.z > angleCoords[progressIndex] - 8)
        {
            print(angleCoords[progressIndex]);
            wheelEvent -= checkAngle;
            StartCoroutine(CheckForConfirmation());
        }
    }

    

    void LateUpdate()
    {
        
        wheelEvent?.Invoke();
        
        /*if(gameObject.transform.rotation.eulerAngles.z > 100)
        {
            wheelEvent?.Invoke();
            wheelEvent = null;
        }*/
    }
}
