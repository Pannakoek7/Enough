using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using TMPro;

public class MainCharacter : MonoBehaviour
{
    
    [Serializable]
    public class MainText
    {
        public string[] Start, Throttle, Silent, Progress;
    }

    string json = @"{
        'Start' : [
            'and I will leave everyting behind'
        ],
        'Throttle' : [
            'Let\'s go full force ahead',
            'and never look back'
        ], 
        'Silent' : [
            'Mmmmh, it\'s a bit too silent',
            'I could really use some music',
            'I do have this old radio, but it works a bit weird',
            'I remember it first needs to be able to receive signals',
            'and after that I need to find a place where the signal is strong enough'
        ],
        'Progress' : [
            'Alright! Now for the radio itself...'
        ]
    }";

    public MainText myText; 

    public TMP_Text mcText;

    void Awake()
    {
        myText = JsonConvert.DeserializeObject<MainText>(json);
    }

}
