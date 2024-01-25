using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Drawer : MonoBehaviour
{

    BoxCollider2D[] boxArr;
    SpriteRenderer mySprite;
    [SerializeField] Sprite openDrawer;
    [SerializeField] Sprite closedDrawer;

    void Start()
    {
        boxArr = gameObject.GetComponents<BoxCollider2D>();
        mySprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        for(int i = 0; i < boxArr.Length; i++)
        { 
            boxArr[i].enabled = !boxArr[i].enabled;
        }

        bool openOrClosed = (mySprite.sprite == openDrawer) ? mySprite.sprite = closedDrawer : mySprite.sprite = openDrawer;
    }
}

