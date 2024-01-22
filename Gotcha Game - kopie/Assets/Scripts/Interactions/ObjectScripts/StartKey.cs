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
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        StartKeyEvent?.Invoke();
        this.enabled = false;
    }
}
