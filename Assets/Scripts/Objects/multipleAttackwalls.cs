using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multipleAttackwalls : MonoBehaviour
{
    //public GameObject cs;
    public PlayerMovement Dash;
    public int count;

    public SpriteRenderer spriteR;

    public Sprite BrokenWall;

    private void Start()
    {
        spriteR = GetComponentInChildren<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            if (Dash.Dashing)
            {
                Debug.Log("hit1");
                if (count!=0)
                {
                    spriteR.sprite = BrokenWall;
                    count--;
                }
                
                else if (count == 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
