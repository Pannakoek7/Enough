using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throttle : Slide
{
    
    myDelegate ThrottleEvent;
    protected override void Start()
    {
        base.Start();
     
        ThrottleEvent += () => {tHandler.ProgressText(protChapter.Throttle, protaginist);};
        ThrottleEvent += () => {StartCoroutine(Waiting());};
        ThrottleEvent += () => {bCol.myState = BoolCollection.State.BrokenRadio;};
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(12);
        
        tHandler.ProgressText(protChapter.Silent, protaginist);
        objHandler.ChangeTask(quest.EnableRadio);
    }

    protected override void Update()
    {
        base.Update();

        if(gameObject.transform.position.y == maxLength)
        {
            if(bCol.myState == BoolCollection.State.Sail)
            {
                ThrottleEvent?.Invoke();
                ThrottleEvent = null;
            }
            
        }
    }

    
}
