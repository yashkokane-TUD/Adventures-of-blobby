using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercheck : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        
    }
    /*private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            miniBoss.speed = 6f;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            miniBoss.speed = 3f;
        }
        
    }*/
}
