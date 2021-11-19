using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class activateObjects : MonoBehaviour
{

    public GameObject cs;
    public GameObject cs1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            cs.SetActive(true);
            cs1.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        cs.SetActive(false);
        cs1.SetActive(false);
        
    }
}
