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
        public string[] Appointment, Incoherent;
    }

    string json = @"{
        'Appointment' : [
            'Once again I\'m sorry I couldn\'t go to your birthday{r}',
            'Maybe we can meet up next week somewhere?'
        ],
        'Static' : [
            'Krrrghhh.....tsrrr....hssss',
            '....gzzgzht....',
            'pfssst....bzzztzt'
        ],
        'Incoherent' : [
            'He...bzzzzrt...Hey'
        ]
    }";

    public RadioMessages myRadio;
    public TMP_Text radioText;

    void Awake()
    {
        myRadio = JsonConvert.DeserializeObject<RadioMessages>(json);
    }

}
