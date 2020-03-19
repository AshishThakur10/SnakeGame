using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    Vector2 swipeStart; // strat of the touch
    Vector2 swipeEnd;
    float minimumDistance = 10;

    public static event System.Action<SwipeDirection> OnSwipe = delegate {};

    public enum SwipeDirection
    {
        Up,Down,Left,Right
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                swipeStart = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                swipeEnd = touch.position;
                ProcessSwipe();
            }
        }

        // mouse Touch 
        if (Input.GetMouseButtonDown(0))
        {
            swipeStart = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            swipeEnd = Input.mousePosition;
            ProcessSwipe();         // call the process Swipe function
        }
            
    }

    void ProcessSwipe()
    {
        float distance = Vector2.Distance(swipeStart, swipeEnd);
        if (distance > minimumDistance)
        {
            if (IsVerticalSwipe())
            {
                if (swipeEnd.y > swipeStart.y)
                {
                    OnSwipe(SwipeDirection.Up);    //up
                }
                else
                {
                    OnSwipe(SwipeDirection.Down);  //down
                }
            }
            else
            {
                if(swipeEnd.x > swipeStart.x)
                {
                    OnSwipe(SwipeDirection.Right);  //right
                }
                else
                {
                    OnSwipe(SwipeDirection.Left);  //left
                }
            }
        }
    }

    bool IsVerticalSwipe()
    {
        float virtical = Mathf.Abs(swipeEnd.y - swipeStart.y);
        float horizontal = Mathf.Abs(swipeEnd.x - swipeStart.x);
        if (virtical> horizontal)
        
            return true;
            return false;
        
    }

}
