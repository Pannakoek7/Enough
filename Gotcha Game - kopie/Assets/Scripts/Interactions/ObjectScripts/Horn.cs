using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horn : ParentInteraction
{

    [SerializeField] Animator seagull;
    private SpriteRenderer noise;

    protected override void Start()
    {
        base.Start();
        var getSprite = GetComponentsInChildren<SpriteRenderer>(true);
        noise = getSprite[1];
    }
    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        StartCoroutine(Sound());
        //Play sound
        if(gameState.myState == StateHandler.State.Seagull)
        {
            if(protaginist.text == "")
            {
                seagull.SetTrigger("Leave");
                StartCoroutine(KeyFalling());
                //gameState.myState = StateHandler.State.Start;
            }
        }
    }    

    IEnumerator KeyFalling()
    {
        yield return new WaitForSeconds(seagull.GetCurrentAnimatorStateInfo(0).length + 2);
        seagull.SetTrigger("Falling");
        yield return new WaitForSeconds(seagull.GetCurrentAnimatorStateInfo(0).length);
        dialogue.ChangeTask(quest.Treasure);
        seagull.enabled = false;
    }

    IEnumerator Sound()
    {
        noise.enabled = true;
        yield return new WaitForSeconds(2);
        noise.enabled = false;
    }
}
