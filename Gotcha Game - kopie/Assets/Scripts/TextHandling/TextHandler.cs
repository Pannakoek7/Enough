using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UIElements;

public class TextHandler : MonoBehaviour
{
    public void ProgressText(string[] sa, TMP_Text tt, int i = 0, TMP_Text ttwo = null)
    {      
        StartCoroutine(Scrolling(sa, tt, i, ttwo));
    }

    private IEnumerator Scrolling(string[] sa, TMP_Text tt, int i, TMP_Text ttwo = null)
    {

        DynamicConversation(sa, ref tt, i, ref ttwo);
        
        tt.text = sa[i];
        yield return new WaitForSeconds(3);
        tt.text = " ";
        yield return new WaitForSeconds(.5f);
        i++;
        if(i < sa.Length)
        {
            StartCoroutine(Scrolling(sa, tt, i, ttwo));
        } else {
            tt.text = "";
            if(ttwo != null)
            {
                ttwo.text = "";
            }
        }
    }

    private string whoIsTalking;

    void DynamicConversation(string[] sa, ref TMP_Text tt, int i, ref TMP_Text ttwo)
    {
        //var meta = sa[i].Substring(sa[i].Length-3);
        //var finalString = sa[i].Remove(sa[i].Length - 3);

        var meta = sa[i].Split("#");
        var finalString = meta[0];

        if(meta.Length > 1)
        {
            if(whoIsTalking != meta[1] && i != 0)
            {
                whoIsTalking = meta[1];
                print(meta[1]);
                var newTMP = ttwo;
                var oldTMP = tt;
                tt = newTMP;
                ttwo = oldTMP;
            } else if(i==0)
            {
                whoIsTalking = meta[1];
            }        
        }

        sa[i] = finalString;
        
    }

}
