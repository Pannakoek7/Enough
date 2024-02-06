using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using TMPro;
using UnityEngine.UI;

public partial class Dialogue : MonoBehaviour
{
    
    [Serializable]
    public class MainText
    {
        public string[] Prologue, Start, Throttle, Silent, Progress, Think, Void, Mouth, Figurine, Plunder, Resentment, BrokenWheel, Horn, Done, Thankless, Content, 
        SignalOne, SignalTwo, SignalThree, Seagull;
    }

    string prot = @"{
        'Prologue' : [
            'I have had enough'
        ],
        'Start' : [
            'and I\'ll leave everyting behind'
        ],
        'Throttle' : [
            'Let\'s go full steam ahead,',
            'and never look back'
        ], 
        'Silent' : [
            'Mmmmh, it\'s a bit too silent',
            'ugh',
            'There is this old radio, but they told me it worked a bit weird',
            'Unfortunately, I only scanned through the manual',
            'I remember it needing to be able to receive signals',
            'as well as some place where the magnetic signal is strong enough',
            'There must be some instrument around that can show me that'
        ],
        'Progress' : [
            'Alright! Now for the radio itself...'
        ],
        'Think' : [
            'Nobody came to my birthday',
            'I even hired this little boat already',
            'I guess I could\'ve seen it coming,',
            'Everyone around me has been so busy lately' 
        ],
        'Void' : [
            'I don\'t need anybody',
            'Today I will celebrate my birthday,',
            'with the salty sea, the fish and the wind in my sails',
            '(Despite the boat being motor driven.)' 
        ],
        'Mouth' : [
            'Hey mister seagull',
            'What do you have in your mouth?'
        ],
        'Figurine' : [
            'Would you look at that',
            'The figurine I fought so hard for',
            'It was the last one on the shelf',
            'Me and a friend both reached for it',
            'I took the loot after a decisive win in rock, paper, scissors',
            'I could tell they really wanted it'
        ],
        'Plunder' : [
            'It has been on my shelf ever since that day',
            'We were on holiday in a foreign country',
            'The figurine was tied to some local legend',
            'About a man who defeated evil spirits,',
            'Who threatened to ruin that year\'s harvest',
            'saving the village from a catastrophe',
            'Maybe it would\'ve been better if he didn\'t,',
            'Since I got food poisoning on the last day'
        ],
        'Resentment' : [
            'I feel like that was the moment cracks began to form',
            'A lot of unspoken tension came afterwards from them',
            'You could just feel the bad energy',
            'I must say it didn\'t really bother me in the end',
            'Maybe it wasn\'t only the figurine,',
            'who knows'
        ],
        'BrokenWheel' : [
            'uuuuh... I could probably reattach that',
            'Lousy quality...'
        ],
        'Horn' : [
            'Here I come world!'
        ],
        'Done' : [
            'That\'s it?',
            'Just me and my ship again?'
        ],
        'Thankless' : [
            'I guess that\'s the way it goes',
            'Everyone gets interested in different things,',
            'and you try to show interest,',
            'but often times it doesn\'t feel like you get anything in return',
            'and after that, things just fade away',
            'just like the gas in my tank',
            'Time to head back'
        ],
        'Content' : [
            'Just the way I like it',
            'I never knew the sea could be this weird',
            'One day I will sail the seven seas and make an encyclopedia',
            'with all mythical creatures',
            'But for now I should probably start to head back'
        ],
        'SignalOne' : [
            'The signal seems to be broken somehow'
        ],
        'SignalTwo' : [
            'No more sea shanties?',
            'bzzzzzzzzzzt#r',
            'I guess not#p'
        ],
        'SignalThree' : [
            'Looks like they went off air',
            'What were they even talking about?' 
        ],
        'Seagull' : [
            'Just let go already!',
            'Caw aw#w'
        ]
    }";

    public MainText myText; 

    public TMP_Text mcText;

    void Awake()
    {
        myText = JsonConvert.DeserializeObject<MainText>(prot);
        myRadio = JsonConvert.DeserializeObject<RadioMessages>(radiomsg);
        myObj = JsonConvert.DeserializeObject<Objectives>(obj);
        myChoice = JsonConvert.DeserializeObject<Choice>(pick);
        myWildlife = JsonConvert.DeserializeObject<CreatureText>(wildlife);

        //objective special case
        ChangeTask(myObj.TurnKey);

        //choice special case
        buttons = new GameObject[2] {choiceOne, choiceTwo};
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().onClick.AddListener(DisableChoice);
        }
        
    }

}

//Feedback list

/*
    - add: enjoy the calm quest during breaks
    - muzieknootjes //DONE
    - add textboxes
    - change the sprite for radiopointer to show 3 channels
    - Being able to click away the first message
    - Message for the key
    - change text when finding figurine
    - grey blue ocean
    - add text to wheel easter egg //Done
    - radio antenna coded weirdly
    - Change around sentences a bit //MostlyDone
    - choice not interesting enough, how to make it more interesting
    - test puzzles

    //IMPORTANT
    
    - msg only plays once when throwing shit in the ocean //NOTWORTHITFORNOW
    - research into wheel hitbox overlapping //NOTWORTHITFORNOW
    - crab breaks string anchor //NOTWORTHITFORNOW
    - Horn msg //NOTWORTHITFORNOW
    - show little sign for throttle //NOTWORTHITFORNOW

    - make function for things that only play once //KEEP IN MIND FOR LATER

    - add to mystical creatures //DONE
    - Message fortext the key //DONE
    - text think about it after wheel seagull dings //DONE
    - change the sprite for radiopointer to show 3 channels //DONE
    - finish mermaid sprites //DONE

    - add: enjoy the calm quest during breaks //MOSTLYDONE

    - change text when finding figurine //add text at the end of the sea shanty // being able to click the treasure chest and a msg plays  

    - sound effect for horn or make a sprite ig; //DONE
    - replay puzzle message
*/
