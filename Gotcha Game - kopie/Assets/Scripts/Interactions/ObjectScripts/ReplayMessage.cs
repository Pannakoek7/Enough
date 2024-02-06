using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReplayMessage : ParentInteraction
{
    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        if(gameState.myState == StateHandler.State.SpinningWheel)
        {
            tHandler.ProgressText(radioChapter.Shanty, radio, true, 2);
        }
    }
}
