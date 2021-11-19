using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collusionChecker : MonoBehaviour
{
    private Enemy Enemy;

    private MovingEnemy2 E2;
    private void Start()
    {
        Enemy = FindObjectOfType<Enemy>();
    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy_Bot")
        {
            //Debug.Log("enemy bot hit");
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Enemy.EnemyHealth();
            Destroy(gameObject);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Ground")
        {
            //Debug.Log("hit");
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Enemy_Bot")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            Enemy.EnemyHealth();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "AbilityEnemy")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "DropEnemy")
        {
            Destroy(gameObject);
        }
    }
}
