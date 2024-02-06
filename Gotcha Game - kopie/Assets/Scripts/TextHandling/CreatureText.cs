using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using TMPro;
using UnityEngine.UI;

public partial class Dialogue
{


    [Serializable]
    public class CreatureText
    {
        public string[] MermaidCrab, MermaidShell, MermaidFigurine, KrakenCrab, KrakenAnchor, KrakenFigurine, FishShell, FishAnchor, FishFigurine, 
        Snapping, HappyFish, HappyMermaid, HappyKraken;
    }

    public CreatureText myWildlife; 
    public TMP_Text wildlifeText;

    string wildlife = @"{
        'MermaidCrab' : [
            'I\'m allergic to crab'
        ],
        'MermaidShell' : [
            'It certainly is pretty',
            'But I like jewelry better'
        ],
        'MermaidFigurine' : [
            'I\'m too old for this',
            'After 200 years you really start realizing what is important'
        ],
        'HappyMermaid' : [
            'This will make a perfect necklace!'
        ],
        'KrakenCrab' : [
            'It snapped at me!'
        ],
        'KrakenAnchor' : [
            'I have collected enough of these over the years' 
        ],
        'KrakenFigurine' : [
            'What a scary looking figure!'
        ],
        'HappyKraken' : [
            'I\'ll be destroying ships in style now'
        ],
        'FishShell' : [
            'This won\'t do for bait!'   
        ],
        'FishAnchor' : [
            'Staying in one place is dangerous',
            'I heard there\'s a wild kraken on the loose'
        ],
        'FishFigurine' : [
            'This will only keep the fish away'
        ],
        'HappyFish' : [
            'Our vibes are immaculate!'
        ],
        'Snapping' : [
            '<i>SNAP</i>',
            'Ow! Why\'d you do that for?#p'
        ]
    }";
}
