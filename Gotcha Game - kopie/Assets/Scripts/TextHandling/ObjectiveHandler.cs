using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using TMPro;
using Newtonsoft.Json;
using System;


public partial class Dialogue
{
    
    public TMP_Text objective;

    [Serializable]
    public class Objectives
    {
        public string TurnKey, PushThrottle, EnableRadio, ChangeChannel, SeaShanty, Treasure, Calm, Help;
    }

    string obj = @"{
        'TurnKey' : 'Start the ship',
        'PushThrottle' : 'Push the throttle all the way up',
        'EnableRadio' : 'Turn on the radio',
        'ChangeChannel' : 'Change radio channel',
        'SeaShanty' : 'There is something odd about this sea shanty',
        'Treasure' : 'Treasure is waiting',
        'Calm' : 'Enjoy the silence',
        'Help' : 'Help mystical creatures'
        
    }";

    public Objectives myObj; 

    public void ChangeTask(string quest)
    {
        objective.text = quest;
    }
    
}
