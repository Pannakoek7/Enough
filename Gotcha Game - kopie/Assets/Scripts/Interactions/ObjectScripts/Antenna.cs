using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Antenna : Slide
{

    UnityEngine.Vector2 startPosition;
    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected override void Update()
    {
        if(active == true)
        {
            UnityEngine.Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(horizontal == true)
            {
                gameObject.transform.parent.transform.localScale = new UnityEngine.Vector2(Mathf.Clamp(newPosition.x, minLength, maxLength), gameObject.transform.parent.transform.localScale.y);
            }
            else
            {
                //this works for some godforsaken reason
                var yessir = Mathf.Abs((newPosition.y - startPosition.y) * .67f + minLength);
                //Mathf.Clamp(yessir, minLength, maxLength);
                gameObject.transform.parent.transform.localScale = new UnityEngine.Vector2(gameObject.transform.parent.transform.localScale.x, Mathf.Clamp(yessir, minLength, maxLength));
            }
        }

        if(gameObject.transform.parent.transform.localScale.y == maxLength)
        {
            if(gameState.myState == StateHandler.State.Magneticwaves)
            {
                tHandler.ProgressText(radioChapter.Appointment, radio, true, 0, protaginist);
                gameState.myState = StateHandler.State.RadioWorking;
                dialogue.ChangeTask("");
                
                tHandler.afterDialogue += () => {dialogue.EnableChoice(choice.ChoiceOne);};
                //button event dings
                dialogue.RemoveAddFunctions(0, tHandler, protChapter.Think, protaginist);
                dialogue.RemoveAddFunctions(1, tHandler, protChapter.Void, protaginist);
                
                for(int i = 0; i < dialogue.buttons.Length; i++)
                {
                    dialogue.buttons[i].GetComponent<Button>().onClick.AddListener(() => {tHandler.afterDialogue += () => {dialogue.ChangeTask(quest.ChangeChannel);};});
                }
                
            } 
            else if(gameState.myState == StateHandler.State.BrokenRadio) 
            {
                
                tHandler.ProgressText(radioChapter.Static, radio, true, 0, protaginist);
                gameState.myState = StateHandler.State.Receive;
            }

        }
    }
}
