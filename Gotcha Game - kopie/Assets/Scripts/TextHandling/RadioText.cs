using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using TMPro;

public class RadioText : MonoBehaviour
{
    
    [Serializable]
    public class RadioMessages
    {
        public string[] Appointment, Static;
    }

    string json = @"{
        'Appointment' : [
            'He...bzzzzrt...Hey#r',
            'I fixed it it like a champ#p',
            'Once again I\'m sorry I couldn\'t go to your birthday#r',
            'Maybe we can meet up somewhere next week?#r',
            'Wait what, why is this on the radio#p',
            'I do not want to think about this right now#p',
            'Do I?#p'
        ],
        'Static' : [
            'Krrrghhh.....tsrrr....hssss#r',
            'Alright! Now I only need a better signal#p'
        ]
    }";

    public RadioMessages myRadio;
    public TMP_Text radioText;

    void Awake()
    {
        myRadio = JsonConvert.DeserializeObject<RadioMessages>(json);
    }

}
