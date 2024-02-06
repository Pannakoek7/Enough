using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Compass : Drag
{
    UnityEngine.Vector2 finalDestination;
    [SerializeField] int offset;
    protected override void Start()
    {
        base.Start();

        finalDestination = new UnityEngine.Vector2(-5, -3);
        
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        gameObject.transform.rotation = Quaternion.Euler(0,0,0);
    }

    protected override void Update()
    {
        if(active == true)
        {
            UnityEngine.Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = newPosition;
            if(gameObject.transform.parent != null)
            {
                gameObject.transform.parent.transform.position = newPosition;
            }
            
            var delta_x = newPosition.x - finalDestination.x;
            var delta_y = newPosition.y - finalDestination.y;
            var theta_radians = Mathf.Atan2(delta_y, delta_x) * (180/MathF.PI);

            gameObject.transform.rotation = Quaternion.Euler(0,0,theta_radians + offset);

            //offset of .1 to get it correct.
            if(gameObject.transform.position.x > finalDestination.x - .1f && gameObject.transform.position.x < finalDestination.x + .1f)
            {
                if(gameObject.transform.position.y > finalDestination.y - .1f && gameObject.transform.position.y < finalDestination.y + .1f)
                {
                    var c = gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>();
                    c.color = new Color32(255, 199, 81, 255);
                    if(gameState.myState == StateHandler.State.BrokenRadio)
                    {
                        gameState.myState = StateHandler.State.Magneticwaves;
                        tHandler.ProgressText(protChapter.Progress, protaginist);
                    } 
                    else if(gameState.myState == StateHandler.State.Receive)
                    {
                        gameState.myState = StateHandler.State.RadioWorking;
                        tHandler.ProgressText(radioChapter.Appointment, radio, true, 0, protaginist);
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
                }
            }
        }
    }
}
