using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartKey : ParentInteraction
{
    myDelegate StartKeyEvent;

    protected override void Start()
    {
        base.Start();
        StartKeyEvent += () => {objHandler.ChangeTask(quest.PushThrottle);};
        //lambda to pass parameter
        //Chapter first parameter, who says it second parameter
        StartKeyEvent += () => {tHandler.ProgressText(protChapter.Start, protaginist);};
        StartKeyEvent += () => 
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            gameObject.transform.parent.transform.rotation = Quaternion.Euler(0,0,270);
            bCol.myState = BoolCollection.State.Sail;
        };
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        if(bCol.myState == BoolCollection.State.Start)
        {
            StartKeyEvent?.Invoke();
            StartKeyEvent = null;
        }
    }
}
