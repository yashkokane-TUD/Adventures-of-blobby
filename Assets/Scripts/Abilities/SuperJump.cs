using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SuperJump : MonoBehaviour
{
    public PlayerMovement _SuperJump;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _SuperJump.canSJ = true;
       
            Destroy(gameObject);
            
        }
    }

}
