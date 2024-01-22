using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : Rotate
{
    myDelegate wheelEvent;

    protected override void Start()
    {
        //Add function to event
        //Lambda function to pass parameters
        base.Start();
        //wheelEvent += () => {tHandler.ProgressText(protChapter.Intro, radio);};
        
        print("THREE");
    }

    void LateUpdate()
    {
        if(gameObject.transform.rotation.eulerAngles.z > 100)
        {
            wheelEvent?.Invoke();
            wheelEvent = null;
        }
    }
}
