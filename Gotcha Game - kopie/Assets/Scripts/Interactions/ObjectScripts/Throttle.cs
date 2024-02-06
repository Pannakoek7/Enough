using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throttle : Slide
{
    
    myDelegate ThrottleEvent;
    protected override void Start()
    {
        base.Start();
     
        ThrottleEvent += () => {
            tHandler.ProgressText(protChapter.Throttle, protaginist);
            tHandler.afterDialogue += () => {dialogue.ChangeTask(quest.Calm);};
            StartCoroutine(Waiting());
            gameState.myState = StateHandler.State.BrokenRadio;
        };
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(12);
        if(protaginist.text == "")
        {
            tHandler.ProgressText(protChapter.Silent, protaginist);
            tHandler.afterDialogue += () => {dialogue.ChangeTask(quest.EnableRadio);};
        } 
        else
        {
            StartCoroutine(Waiting());
        }
        
    }

    protected override void Update()
    {
        base.Update();

        if(gameObject.transform.position.y == maxLength)
        {
            if(gameState.myState == StateHandler.State.Sail)
            {
                ThrottleEvent?.Invoke();
                ThrottleEvent = null;
            }
        }
    }

    
}
