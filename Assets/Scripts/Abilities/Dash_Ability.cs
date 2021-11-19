using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dash_Ability : MonoBehaviour
{
    public PlayerMovement Dash;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Dash.canDash = true;
            Destroy(gameObject);
            
            /*Debug.Log(("Dash"));*/
       
        }
    }
  
}
