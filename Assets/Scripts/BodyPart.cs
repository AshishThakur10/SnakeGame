﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    Vector2 dPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMovement(Vector2 movement)
    {
        dPosition = movement;
    }
    public void UpdatePosition()
    {
        gameObject.transform.position += (Vector3)dPosition;
    }
    public void UpdateDirection()
    {
        if (dPosition.y > 0)
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        else if (dPosition.y < 0)
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 180);
        else if (dPosition.x < 0)
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 90);
        else if (dPosition.x > 0)
            gameObject.transform.localEulerAngles = new Vector3(0, 0, -90);

    }
}
