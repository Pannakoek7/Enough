using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using TMPro;
using Newtonsoft.Json;
using System;


public class ObjectiveHandler : MonoBehaviour
{
    
    public TMP_Text objective;
    
    /*private List<string> tasks = new List<string>();
    private int taskNumber;

    void Start()
    {
        string readFromFilePath = Application.streamingAssetsPath + "/Objective" + ".txt";
        tasks = File.ReadAllLines(readFromFilePath).ToList();

        ChangeTask();
    }

    public void ChangeTask()
    {
        if(taskNumber < tasks.Count)
        {
            objective.text = tasks[taskNumber];
        }
        
        taskNumber++;

        //Might need a parameter if task description depends on player action.
        //Maybe a optional parameter 
        
        //Might just turn this into JSON as well tbh, I believe in JSON surpremacy;
    }*/


    [Serializable]
    public class Objectives
    {
        public string TurnKey, PushThrottle, EnableRadio;
    }

    string json = @"{
        'TurnKey' : 'Start the ship',
        'PushThrottle' : 'Push the throttle all the way up',
        'EnableRadio' : 'Turn on the radio'
        
    }";

    public Objectives myObj; 

    void Awake()
    {
        myObj = JsonConvert.DeserializeObject<Objectives>(json);
    }

    void Start()
    {
        ChangeTask(myObj.TurnKey);
    }

    public void ChangeTask(string quest)
    {
        objective.text = quest;
    }
    
}
