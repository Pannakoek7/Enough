using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartKey : ParentInteraction
{
    myDelegate StartKeyEvent;

    protected override void Start()
    {
        base.Start();
        StartKeyEvent += () => {dialogue.ChangeTask(quest.PushThrottle);};
        //lambda to pass parameter
        //Chapter first parameter, who says it second parameter
        StartKeyEvent += () => {tHandler.ProgressText(protChapter.Start, protaginist);};
        StartKeyEvent += () => 
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            gameObject.transform.parent.transform.rotation = Quaternion.Euler(0,0,270);
            gameState.myState = StateHandler.State.Sail;
        };

        //First message
        tHandler.ProgressText(protChapter.Prologue, protaginist);
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        if(gameState.myState == StateHandler.State.Start)
        {
            StartKeyEvent?.Invoke();
            StartKeyEvent = null;
        }
    }
}
