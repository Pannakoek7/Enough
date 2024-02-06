using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class Spyglass : ParentInteraction
{
    bool zooming;
    float opacity = 0;
    [SerializeField] SpriteRenderer zoomed;
    [SerializeField] SpriteRenderer lurking;

    internal List<Sprite> creatures;
    internal List<Sprite> happyCreatures;
    [SerializeField] Sprite mermaid, fish, kraken, empty, seagullZoomed;
    [SerializeField] Sprite happyMermaid, happyFish, happyKraken;

    internal enum CorrectObject
    {
        Anchor,
        Crab,
        Shell
    }

    internal CorrectObject trinkets = CorrectObject.Shell;

    protected override void Start()
    {
        base.Start();
        creatures = new List<Sprite>(3) {mermaid, fish, kraken};
        happyCreatures = new List<Sprite>(3) {happyMermaid, happyFish, happyKraken};
    }

    protected override void OnMouseDown()
    {
        zooming = true;
        var changeSprite = (trinkets != (CorrectObject)2) ? trinkets++ : trinkets = (CorrectObject)0;
        
        if(gameState.myState == StateHandler.State.Throwing)
        {
            lurking.sprite = creatures[(int)trinkets];   
        } 
        else if(gameState.myState == StateHandler.State.Seagull)
        {
            lurking.sprite = seagullZoomed;
        }
        else
        {
            lurking.sprite = empty;
        }
    }

    protected override void OnMouseUp()
    {
        zooming = false;
    }

    void FixedUpdate()
    {
        if(zooming == true && opacity < 1.01f)
        {
            opacity += .05f;
            zoomed.color =  new Color(1,1,1, opacity);
            lurking.color = new Color(1,1,1, opacity);
        } 
        else if(zooming == false && opacity > -0.01f)
        {
            opacity -= .05f;
            zoomed.color =  new Color(1,1,1, opacity);
            lurking.color = new Color(1,1,1, opacity);
        }
    }
}
