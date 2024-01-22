using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextHandler : MonoBehaviour
{
    public void ProgressText(string[] sa, TMP_Text tt, int i = 0)
    {      
        StartCoroutine(Scrolling(sa, tt, i));
    }

    private IEnumerator Scrolling(string[] s, TMP_Text tt, int i)
    {
        tt.text = s[i];
        yield return new WaitForSeconds(3);
        tt.text = " ";
        yield return new WaitForSeconds(.5f);
        i++;
        if(i < s.Length)
        {
            print(i);
            StartCoroutine(Scrolling(s, tt, i));
        }
    }

    void DynamicConversation(string[] sa, TMP_Text tt, int i)
    {
        var meta = sa[i].Substring(sa[i].Length-3);
        var finalString = sa[i].Remove(sa[i].Length - 3);
        
        
        if(meta == "{r}")
        {
            //tt = ;
        } else if (meta == "{p}")
        {
            //tt = tt;
        }

        sa[i] = finalString;
        StartCoroutine(Scrolling(sa, tt, i));
    }

    TMP_Text test1;
    TMP_Text test2;
}
