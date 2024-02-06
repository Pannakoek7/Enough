using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RadioPointer : Slide
{

    myDelegate pointerEventOne;
    myDelegate pointerEventTwo;
    float sliderLength;

    [SerializeField] SpriteRenderer replay;

    protected override void Start()
    {
        base.Start();

        sliderLength = maxLength - minLength;

        pointerEventOne += () => { 
            tHandler.ProgressText(radioChapter.Shanty, radio);
            tHandler.afterDialogue += () => {dialogue.ChangeTask(quest.SeaShanty);};
            gameState.myState = StateHandler.State.SpinningWheel;
            
            replay.color = new Color32(255, 199, 81, 255);
        };

        pointerEventTwo += () => {   
            tHandler.ProgressText(radioChapter.Endangered, radio);
            tHandler.afterDialogue += () => {
                dialogue.ChangeTask(quest.Help);
                tHandler.ProgressText(radioChapter.Podcast, radio, false);

                replay.color = new Color32(255, 255, 255, 255);
            };
            gameState.myState = StateHandler.State.Throwing;
        };
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        if((int)gameState.myState >= 5)
        {
            if(gameObject.transform.position.x > (sliderLength * 0.67f) + minLength )
            {
                print("mythical creature quest");
                pointerEventTwo?.Invoke();
                pointerEventTwo = () => {tHandler.ProgressText(protChapter.SignalThree, protaginist);};
            }
            else if(gameObject.transform.position.x > (sliderLength * 0.33) + minLength)
            {
                print("sea shanty quest");
                pointerEventOne?.Invoke();
                pointerEventOne = () => {tHandler.ProgressText(protChapter.SignalTwo, protaginist, true, 0, radio);};
            } 
            else
            {
                tHandler.ProgressText(protChapter.SignalOne, protaginist, true, 0, radio);
            }
        }
    }
}
