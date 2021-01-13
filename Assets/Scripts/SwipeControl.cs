using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SwipeControl : MonoBehaviour
{
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;

    private Rigidbody2D rb;

    [Range (0.05f, 1f)]
    public float throwForce = 0.3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AddForceWithSwipe();
        
        AddForceWithMouseInput();
    }

    private void AddForceWithSwipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;
            endPos = Input.GetTouch(0).position;
            direction = startPos - endPos;
            rb.AddForce(-direction / timeInterval * throwForce);
        }
    }

#if UNITY_EDITOR

    private void AddForceWithMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchTimeStart = Time.time;

            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;
            endPos = Input.mousePosition;
            direction = startPos - endPos;
            rb.AddForce(-direction / timeInterval * throwForce);
        }
    }
    
#endif
}
