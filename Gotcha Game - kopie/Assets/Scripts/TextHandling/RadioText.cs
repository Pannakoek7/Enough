using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using TMPro;

public partial class Dialogue
{
    
    [Serializable]
    public class RadioMessages
    {
        public string[] Appointment, Static, Shanty, Trash, Endangered, Podcast;
    }

    string radiomsg = @"{
        'Appointment' : [
            'He...bzzzzrt...Hey#r',
            'See, reading manuals is overrated#p',
            'Once again I\'m sorry I couldn\'t go to your birthday#r',
            'Maybe we can meet up somewhere next week?', 
            'Wait what, why is this on the radio#p', 
            'I don\'t want to think about this right now',
            'Do I?'
        ],
        'Static' : [
            'Krrrghhh.....tsrrr....hssss#r',
            'Alright! Now I only need a better signal#p'
        ],
        'Shanty' : [
            'Welcome to the sea shanty channel',
            'Playing: Where the wind takes me',
            '♪ One day I set out to look for treasure ♫',
            '♪ but after 225 miles I didn\'t know where I was ♫',
            '♪ Having seen no land, ♫',
            '♪ Having touched no sand ♫',
            '♪ <i>Instrumentals</i> ♫',
            '♪ Not wanting to turn back ♫',
            '♪ I spend 90 days on deck ♫',
            '♪ But the tides turned ♫',
            '♪ and the wind blew <b>south</b> ♫',
            '♪ slowly, my supplies ran out ♫',
            '♪ I wrote a song to ease the pain ♫',
            '♪ while the wind blew my ship away ♫'
        ],
        Trash : [
            'Please do not throw yourself or other things in the ocean,',
            'We already have enough trash in the sea'
        ],
        Endangered : [
            'Wonderful story Jonny',
            'Continuing with the local news',
            'A lot of mystical creatures have been spotted',
            'People, when you see any of them, please support these sweethearts',
            'These creatures are endangered, and need any help they can get',
            'If you have anything in your ship you don\'t need,',
            'Throw it out your ship with a good ol\' swing' 
        ],
        Podcast : [
            'Dear viewers, sit back, relax, and just let us talk',
            'What\'s your favorite mystical creature Jonny?',
            'The elusive fish in a barrel, Craig',
            'When I go out fishing I meet him at times,',
            'and then we share tips and tricks,',
            'that fish knows what he\'s doing',
            'That\'s super lame, Jonny',
            'I heard there are some mermaids out there',
            'What I would do is buy a really big fishbowl,',
            'and save them from these dangerous waters',
            'Craig, to be completely honest,', 
            'they wouldn\'t even want to be saved by you even if they were being chased by a big shark',
            'Why do you think that is Jonny?',
            'It\'s definitely your face Craig, it\'s appaling',
            'I can\'t argue with that Jonny, however,',
            'Have you seen the Kraken? Absolutely no fashion taste, at least I try',
            'It is indeed curious Craig that they have not evolved in the fashion department',
            'Jonny, can you stop talking for a bit',
            'you\'re being extremely boring',
            ' And you\'re a dickhead Craig, why won\'t you just let me talk for a bit?',
            'You always take the spotlight at any chance',
            'Oh here we go again',
            'bzzzzt...<i>Lost signal</i>...bzzzzt' 
        ]

    }";

    public RadioMessages myRadio;
    public TMP_Text radioText;
}

//♪ ♫
