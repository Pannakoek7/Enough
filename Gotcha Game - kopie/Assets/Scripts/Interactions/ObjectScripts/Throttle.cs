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
        //ThrottleEvent += () => {bCol.ToOpposite(ref bCol.hasStarted);};
        ThrottleEvent += () => {StartCoroutine(Waiting());};
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(10);
        
        tHandler.ProgressText(protChapter.Silent, protaginist);
        objHandler.ChangeTask(quest.EnableRadio);
        //bCol.ToOpposite(ref bCol.radioActive);
    }

    protected override void Update()
    {
        base.Update();

        if(gameObject.transform.position.y == maxLength)
        {
            ThrottleEvent?.Invoke();
            ThrottleEvent = null;
        }
    }

    
}
