using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextHandler : MonoBehaviour
{

    internal delegate void AfterText();
    internal AfterText afterDialogue;



    public void ProgressText(string[] sa, TMP_Text tt, bool manual = true, int i = 0, TMP_Text ttwo = null)
    {     
        //manual = false; 
        if(manual == true)
        {
            //I hate this if statement
            if(tt.gameObject.name == "RadioText")
            {
                StopAllCoroutines();
            }

            Manual(sa, tt, i, ttwo);                
        } 
        else
        {
            StartCoroutine(Scrolling(sa, tt, i, ttwo));
        }
    }

    private IEnumerator Scrolling(string[] sa, TMP_Text tt, int i, TMP_Text ttwo = null)
    {
        DynamicConversation(sa, ref tt, i, ref ttwo);
        
        tt.text = sa[i];
        yield return new WaitForSeconds(4);
        tt.text = " ";
        yield return new WaitForSeconds(.5f);
        i++;
        if(i < sa.Length)
        {
            StartCoroutine(Scrolling(sa, tt, i, ttwo));
        } 
        else
        {
            tt.text = "";
            if(ttwo != null)
            {
                ttwo.text = "";
            }

            afterDialogue?.Invoke();
            afterDialogue = null;
        }
    }

    internal bool talking;
    struct MyParameters
    {
        public string[] psa;
        public int pi;
        public TMP_Text ptt;
        public TMP_Text pttwo;

        public MyParameters(string[] psa, TMP_Text ptt, int pi, TMP_Text pttwo)
        {
            this.psa = psa;
            this.pi = pi;
            this.ptt = ptt;
            this.pttwo = pttwo;
        }
    }

    MyParameters myPar;

    void Manual(string[] sa, TMP_Text tt, int i, TMP_Text ttwo = null)
    {
        if(i != sa.Length )
        {
            DynamicConversation(sa, ref tt, i, ref ttwo);
            tt.text = sa[i];
            if(ttwo != null)
            {
                ttwo.text = "";
            }
        }

        if(i < sa.Length)
        {
            i++; 
            StartCoroutine(Frame());
        } 
        else if(i == sa.Length)
        {
            tt.text = "";
            if(ttwo != null)
            {
                ttwo.text = "";
            }

            talking = false;

            afterDialogue?.Invoke();
            afterDialogue = null;
        }

        myPar = new MyParameters(sa, tt, i, ttwo);

        IEnumerator Frame()
        {
            yield return new WaitForEndOfFrame();
            talking = true;
        }
    }

    private string whoIsTalking;
    void DynamicConversation(string[] sa, ref TMP_Text tt, int i, ref TMP_Text ttwo)
    {
        //Check for 'metadata'
        if(!sa[i].Contains("#"))
        {
            return;
        }

        var meta = sa[i].Split("#");
        var finalString = meta[0];

        if(meta.Length > 1)
        {
            if(whoIsTalking != meta[1] && i != 0)
            {
                //Change who is yapping
                whoIsTalking = meta[1];
                (tt, ttwo) = (ttwo, tt);
            } 
            else if(i==0)
            {
                //establish who is yapping
                whoIsTalking = meta[1];
            }        
        }

        sa[i] = finalString;
    }

    void Update()
    {
        if(talking == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Manual(myPar.psa, myPar.ptt, myPar.pi, myPar.pttwo);
            }
        }
    }

}
