using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Throw : Drag
{
    //throwing mechanic
    private bool thrown;
    bool trash;
    protected bool OutOfBounds;

    List<UnityEngine.Vector2> positions = new List<Vector2>(5);
    int listCount;
    float speedX;
    float speedY;
    const float decreaseSpeed = .05f;

    void NewSpeed(ref float v, float decrease = decreaseSpeed)
    {
        v = (v > 0) ? v -= decrease : v += decrease;
    }

    void FixedUpdate()
    {
        //Make list of Vectors
        if(active == true)
        {
            if(positions.Count == positions.Capacity)
            {
                positions.RemoveAt(0);
            }
            positions.Add(gameObject.transform.position);
        }

        //when the player unclicks, calculate the velocity of the object and move it
        if(thrown == true)
        {
            if(Mathf.Abs(speedX) > Mathf.Abs(speedY))
            {
                float customDecreaseSpeed = Mathf.Abs(speedY)/Mathf.Abs(speedX) * decreaseSpeed;
                NewSpeed(ref speedX);
                NewSpeed(ref speedY, customDecreaseSpeed);
            } 
            else
            {
                var customDecreaseSpeed = Mathf.Abs(speedX)/Mathf.Abs(speedY) * decreaseSpeed;
                NewSpeed(ref speedX, customDecreaseSpeed);
                NewSpeed(ref speedY);
            }
            
            //I hate this if statement as well
            if(listCount != 0)
            {
                gameObject.transform.Translate(speedX * (Time.fixedDeltaTime * (50/listCount)), speedY * (Time.fixedDeltaTime * (50/listCount)), 0, Space.Self);
            }
            
            if((speedX <= decreaseSpeed && speedX >= -decreaseSpeed) || (speedY <= decreaseSpeed && speedY >= -decreaseSpeed))
            {
                CheckOutBounds();
                thrown = false;
                if(trash == true)
                {
                    if(gameState.myState != StateHandler.State.Throwing)
                    {
                        tHandler.ProgressText(radioChapter.Trash, radio);
                    }
                    trash = false;
                }                
            }     
        }
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        //Calculate average change in positions
        if(thrown != true)
        {
            listCount = positions.Count;

            if(listCount != 0)
            {
                var newVector = new Vector3(
                positions.Average(positions => positions.x),
                positions.Average(positions => positions.y));
                
                speedX = (gameObject.transform.position.x - newVector.x); 
                speedY = (gameObject.transform.position.y - newVector.y);

                if(speedX != 0 && speedY != 0)
                {
                    thrown = true;
                }

                positions.Clear();
            }   
        }  
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        
        thrown = false;
    }

    protected virtual void CheckOutBounds()
    {
        gameObject.TryGetComponent<SpriteRenderer>(out var myObj);
        UnityEngine.Vector2 myVec = myObj.bounds.size;
        float width = myVec.x;
        float height = myVec.y;
        //I should make a reference to the camera
        float cameraSize = 5;
        
        if(gameObject.transform.position.y > cameraSize + (height/2) || gameObject.transform.position.x > (cameraSize * 1.78f) + (width/2) ||
        gameObject.transform.position.y < (cameraSize + (height/2)) * -1 || gameObject.transform.position.x < ((cameraSize * 1.78f) + (width/2)) * -1)
        {
            if(gameObject.activeSelf == true)
            {
                OutOfBounds = true;
                StartCoroutine(ThrowBack());
            }    
        }
        
        IEnumerator ThrowBack()
        {
            yield return new WaitForSeconds(1);
            gameObject.transform.position = new Vector2(cameraSize * -2, -1);
            speedX = 2;
            speedY = 0.5f;

            thrown = true;
            trash = true;
        }
    }
}
