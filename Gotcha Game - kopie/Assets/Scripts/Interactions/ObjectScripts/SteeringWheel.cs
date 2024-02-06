using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SteeringWheel : Rotate
{
    myDelegate wheelEvent;
    //it shows different in editor, but in code it uses 360 going to the left first.
    int[] angleCoords = {135, 280, 179};
    int progressIndex;
    
    [SerializeField] Animator seagull;
    [SerializeField] GameObject lights;
    SpriteRenderer[] littleLights;

    Animator anim;
    

    protected override void Start()
    {
        //Add function to event
        //Lambda function to pass parameters
        base.Start();

        wheelEvent += checkAngle;
        littleLights = lights.GetComponentsInChildren<SpriteRenderer>();
        
        anim = gameObject.GetComponentInChildren<Animator>(true);
    }

    IEnumerator CheckForConfirmation()
    {
        yield return new WaitForSeconds(1f);
        if(transform.rotation.eulerAngles.z < angleCoords[progressIndex] + 8 && transform.rotation.eulerAngles.z > angleCoords[progressIndex] - 8)
        {
            progressIndex += 1;
            print(progressIndex);
            //make lights go green
            littleLights[progressIndex - 1].color = Color.green;
        } 

        if(progressIndex == angleCoords.Length)
        {
            wheelEvent -= checkAngle;
            seagull.SetTrigger("Enter");
            gameState.myState = StateHandler.State.Seagull;
            StartCoroutine(AnimationWait());
        } else {
            wheelEvent += checkAngle;
        }
    }

    IEnumerator AnimationWait()
    {
        yield return new WaitForSeconds(seagull.GetCurrentAnimatorStateInfo(0).length);
        tHandler.ProgressText(protChapter.Mouth, protaginist);
    }



    void checkAngle()
    {
        if(transform.rotation.eulerAngles.z < angleCoords[progressIndex] + 8 && transform.rotation.eulerAngles.z > angleCoords[progressIndex] - 8)
        {
            wheelEvent -= checkAngle;
            StartCoroutine(CheckForConfirmation());
        }
    }

    float lastAngle;  
    float difference;
    List<float> diffCollection = new List<float>();  

    void FixedUpdate()
    {
        if(lastAngle != 0 && active == true)
        {
            difference = Mathf.Abs(lastAngle - theta_radians);
            diffCollection.Add(difference);
            if(diffCollection.Count == 40)
            {
                var number = diffCollection.Average();
                diffCollection.Clear();
                if(number >= 40)
                {
                    //when you spin too much
                    
                    anim.enabled = true;
                    anim.SetTrigger("Spin");
                    
                    StartCoroutine(DisableAnimator());
                    //gameObject.GetComponent<BoxCollider2D>().size = new Vector2(.5f, .5f);
                    tHandler.ProgressText(protChapter.BrokenWheel, protaginist);
                    
                    this.enabled = false;
                }
            }
        }
        lastAngle = theta_radians;
    }

    IEnumerator DisableAnimator()
    {
        yield return new WaitForSeconds(seagull.GetCurrentAnimatorStateInfo(0).length);
        anim.enabled = false;
        gameObject.GetComponentInChildren<SteeringWheelSpecial>(true).enabled = true;
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        diffCollection.Clear();
    }

    void LateUpdate()
    {
        wheelEvent?.Invoke();
    }
}
