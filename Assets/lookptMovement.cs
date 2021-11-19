using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookptMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.1f;
    private Vector3 offset;
    
    
    void LateUpdate()
    {
        if (PlayerMovement.moveDir < 0)
        {
            offset = new Vector3(-8,0,0);
        }
        else
        {
            offset = new Vector3(8,0,0);
        }
        Vector3 desiredPos = player.transform.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, speed);
        transform.position = smoothPos;

    }

}
