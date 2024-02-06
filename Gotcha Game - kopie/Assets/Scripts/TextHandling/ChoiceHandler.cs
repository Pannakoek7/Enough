using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public partial class Dialogue
{
   
    [Serializable]
    public class Choice
    {
        public string[] ChoiceOne;
    }

    string pick = @"{
        'ChoiceOne' : [
            'Think about it',
            '<b>Don\'t</b> think about it'
        ]
    }";

    public Choice myChoice;
    [SerializeField] GameObject choiceOne;
    [SerializeField] GameObject choiceTwo;
    internal GameObject[] buttons;

    internal void EnableChoice(string[] sa)
    {
        choiceOne.GetComponentInChildren<TMP_Text>().text = sa[0];
        choiceTwo.GetComponentInChildren<TMP_Text>().text = sa[1];

        for(int i = 0; i < buttons.Length; i++)
        {   
            buttons[i].SetActive(true);
        }
    }

    //I might have to add some parameters later on
    internal void RemoveAddFunctions(int bNumber, TextHandler thandler, string[] sa, TMP_Text tt)
    {
        buttons[bNumber].GetComponent<Button>().onClick.RemoveAllListeners();
        buttons[bNumber].GetComponent<Button>().onClick.AddListener(() => {thandler.ProgressText(sa, tt);});

        buttons[bNumber].GetComponent<Button>().onClick.AddListener(DisableChoice);
    }

    void DisableChoice()
    {
        for(int i = 0; i < buttons.Length; i++)
        {   
            buttons[i].SetActive(false);
        }
    }
}
