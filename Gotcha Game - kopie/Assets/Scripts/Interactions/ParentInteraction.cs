using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParentInteraction : MonoBehaviour
{
    //Trigger events
    protected delegate void myDelegate();

    //get text components
    private GameObject hub;
    protected Dialogue dialogue;
    protected TextHandler tHandler;
    protected TMP_Text protaginist;
    protected TMP_Text radio;
    protected TMP_Text wildlife;
    protected Dialogue.RadioMessages radioChapter;
    protected Dialogue.MainText protChapter;
    protected Dialogue.CreatureText wildlifeChapter;
    protected Dialogue.Objectives quest;
    protected Dialogue.Choice choice;

    //get event component
    protected StateHandler gameState;

    protected virtual void Start()
    {
        hub = GameObject.Find("EmptySoEmpty");
        //get gamecomponents
        dialogue = hub.GetComponent<Dialogue>();
        tHandler = hub.GetComponent<TextHandler>();
        gameState = hub.GetComponent<StateHandler>();

        //rename textcomponents
        protaginist = dialogue.mcText;
        radio = dialogue.radioText;
        wildlife = dialogue.wildlifeText;

        //rename chaptercomponents
        radioChapter = dialogue.myRadio;
        protChapter = dialogue.myText;
        wildlifeChapter = dialogue.myWildlife;
        quest = dialogue.myObj;
        choice = dialogue.myChoice;
    }

    //Base mechanic
    protected bool active;

    protected virtual void OnMouseDown()
    {
        if(tHandler.talking == false)
        {
            active = true;
        }
    }

    protected virtual void OnMouseUp()
    {
        active = false;
    }
    
}
