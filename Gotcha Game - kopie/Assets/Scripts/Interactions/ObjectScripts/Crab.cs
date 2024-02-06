using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : Trinket
{
    bool snap = true;
    
    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        StartCoroutine(Snap());

    }

    IEnumerator Snap()
    {
        yield return new WaitForSeconds(1);
        OnMouseUp();
        if(snap == true)
        {
            if(protaginist.text == "")
            {
                tHandler.ProgressText(wildlifeChapter.Snapping, wildlife, true, 0, protaginist);
                snap = false;
            }
            
        }
        
    }
}
