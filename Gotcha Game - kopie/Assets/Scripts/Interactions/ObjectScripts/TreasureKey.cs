using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TreasureKey : Drag
{

    [SerializeField] GameObject chest;
    SpriteRenderer[] sprites;
    LayerMask lm;
    protected override void Start()
    {
        base.Start();
        lm = LayerMask.GetMask("Special");

        sprites = chest.GetComponentsInChildren<SpriteRenderer>(true);
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        if(gameState.myState == StateHandler.State.Seagull)
        {
            tHandler.ProgressText(protChapter.Seagull, protaginist, true, 0, wildlife);
        }
    }

    protected override void Update()
    {
        base.Update();
        if(active == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.zero, 1, lm);

            if(hit && hit.collider.name == "TreasureChest")
            {
                if(sprites.Length != 0)
                {   
                    sprites[0].enabled = false;
                    sprites[1].enabled = true;
                    sprites[2].enabled = true;

                    tHandler.ProgressText(protChapter.Figurine, protaginist);
                    tHandler.afterDialogue += () => {dialogue.EnableChoice(choice.ChoiceOne);};

                    dialogue.RemoveAddFunctions(0, tHandler, protChapter.Resentment, protaginist);
                    dialogue.RemoveAddFunctions(1, tHandler, protChapter.Plunder, protaginist);

                    gameObject.SetActive(false);
                }

            }
        }
    }
}
