using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trinket : Throw
{
    Spyglass spyglass;
    GameObject currentObject;
    static int trinketsGiven;

    protected override void Start()
    {
        base.Start();

        spyglass = gameObject.transform.parent.transform.parent.GetComponent<Spyglass>();
        currentObject = this.gameObject;
    }

    void CheckCorrectObject()
    {
        if(gameState.myState == StateHandler.State.Throwing)
        {
            string objectName = currentObject.name;;

            switch (spyglass.trinkets)
            {
                case Spyglass.CorrectObject.Anchor: //mermaid
                    if(gameObject.name == "Anchor")
                    {
                        print("You threw the right object! (Anchor)");
                        //Change Sprite in the list
                        spyglass.creatures[0] = spyglass.happyCreatures[0];
                        OnQuestComplete();
                        tHandler.ProgressText(wildlifeChapter.HappyMermaid, wildlife);
                    }
                    else
                    {
                        if(OutOfBounds == true)
                        {
                            WrongObject();
                            OutOfBounds = false;
                        }
                    }
                    break;
                case Spyglass.CorrectObject.Crab: //fishie
                    if(gameObject.name == "Crab")
                    {
                        print("You threw the right object! (Crab)");
                        //Change Sprite in the list
                        spyglass.creatures[1] = spyglass.happyCreatures[1];
                        OnQuestComplete();
                        tHandler.ProgressText(wildlifeChapter.HappyFish, wildlife);
                    }
                    else
                    {
                        if(OutOfBounds == true)
                        {
                            WrongObject();
                            OutOfBounds = false;
                        }
                    }
                    break;
                case Spyglass.CorrectObject.Shell: //Kraken
                    if(gameObject.name == "Shell")
                    {
                        print("You threw the right object! (Shell)");
                        //Change Sprite in the list
                        spyglass.creatures[2] = spyglass.happyCreatures[2];
                        OnQuestComplete();
                        tHandler.ProgressText(wildlifeChapter.HappyKraken, wildlife);
                    }
                    else
                    {
                        if(OutOfBounds == true)
                        {
                            WrongObject();
                            OutOfBounds = false;
                        }
                    }
                    break;
                default:
                    //dosomething break;
                    break; 
            }
        }
    }

    void WrongObject()
    {
        var name = gameObject.name;
        if(spyglass.trinkets == Spyglass.CorrectObject.Anchor)
        {
            print("Step 2");
            switch (name)
            {
                case "Shell":
                    tHandler.ProgressText(wildlifeChapter.MermaidShell, wildlife);  
                    break;
                case "Crab":
                    tHandler.ProgressText(wildlifeChapter.MermaidCrab, wildlife);
                    break; 
                case "Figurine":
                    tHandler.ProgressText(wildlifeChapter.MermaidFigurine, wildlife);
                    break;
            } 
        } 
        else if(spyglass.trinkets == Spyglass.CorrectObject.Crab)
        {
            switch (name)
            {
                case "Shell":
                    tHandler.ProgressText(wildlifeChapter.FishShell, wildlife);  
                    break;
                case "Crab":
                    tHandler.ProgressText(wildlifeChapter.FishAnchor, wildlife);
                    break; 
                case "Figurine":
                    tHandler.ProgressText(wildlifeChapter.FishFigurine, wildlife);
                    break;
            }  
        }
        else if(spyglass.trinkets == Spyglass.CorrectObject.Shell)
        {
            switch (name)
            {
                case "Anchor":
                    tHandler.ProgressText(wildlifeChapter.KrakenAnchor, wildlife);  
                    break;
                case "Crab":
                    tHandler.ProgressText(wildlifeChapter.KrakenCrab, wildlife);
                    break; 
                case "Figurine":
                    tHandler.ProgressText(wildlifeChapter.KrakenFigurine, wildlife);
                    break;
            }
        }   
    }

    protected override void CheckOutBounds()
    {
        base.CheckOutBounds();
        CheckCorrectObject();
    }

    void OnQuestComplete()
    {
        gameObject.SetActive(false);
        spyglass.trinkets--;
        trinketsGiven++;

        if(trinketsGiven == 3)
        {
            dialogue.ChangeTask("");
            tHandler.ProgressText(protChapter.Done, protaginist);

            tHandler.afterDialogue += () => {dialogue.EnableChoice(choice.ChoiceOne);};
            
            dialogue.RemoveAddFunctions(0, tHandler, protChapter.Thankless, protaginist);
            dialogue.RemoveAddFunctions(1, tHandler, protChapter.Content, protaginist);
        }
    }
}
