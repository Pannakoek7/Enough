using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParentInteraction : MonoBehaviour
{
    //Base mechanic
    protected bool active;

    protected virtual void OnMouseDown()
    {
        active = true;
    }

    protected virtual void OnMouseUp()
    {
        active = false;
    }

    //Trigger events
    protected delegate void myDelegate();

    //get text components
    private GameObject hub;
    protected ObjectiveHandler objHandler;
    protected TextHandler tHandler;
    protected MainCharacter mainChar;
    protected RadioText rText;
    protected TMP_Text protaginist;
    protected TMP_Text radio;
    protected RadioText.RadioMessages radioChapter;
    protected MainCharacter.MainText protChapter;
    protected ObjectiveHandler.Objectives quest;

    //get event component
    protected BoolCollection bCol;

    protected virtual void Start()
    {
        hub = GameObject.Find("EmptySoEmpty");
        //get gamecomponents
        objHandler = hub.GetComponent<ObjectiveHandler>();
        tHandler = hub.GetComponent<TextHandler>();
        mainChar = hub.GetComponent<MainCharacter>();
        rText = hub.GetComponent<RadioText>();

        //rename textcomponents
        protaginist = mainChar.mcText;
        radio = rText.radioText;

        //rename chaptercomponents
        radioChapter = rText.myRadio;
        protChapter = mainChar.myText;
        quest = objHandler.myObj;

        //test
        bCol = hub.GetComponent<BoolCollection>();

    }
    
}
