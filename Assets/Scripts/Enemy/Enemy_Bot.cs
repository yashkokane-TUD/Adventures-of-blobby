using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bot : MonoBehaviour
{
    public GameObject player;
    public GameObject _enemyBot;



    public float moveSpeed;
    public int pointSelect;
    
    public Transform currentPosition;
    public Transform[] points;
    
    private SpriteRenderer mySR;
    private PlayerMovement pM;
    public  GameObject item1;
    
    // Start is called before the first frame update
    void Start()
    {
        pM = GetComponent<PlayerMovement>();
        mySR = GetComponentInChildren<SpriteRenderer>();
        currentPosition = points[pointSelect];
    }

    // Update is called once per frame
    void Update()
    {
        _enemyBot.transform.position = Vector3.MoveTowards(_enemyBot.transform.position, currentPosition.position,
            moveSpeed * Time.deltaTime);

        if (_enemyBot.transform.position == currentPosition.position)
        {
            pointSelect++;
            mySR.flipX = true;

            if (pointSelect == points.Length)
            {
                pointSelect = 0;
                mySR.flipX = false;
            }

            currentPosition = points[pointSelect];
        }
    }
    
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            /*Debug.Log(("Dash"));
        }
    }
    */
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //DItems.dropItemOnDeath();
            item1.SetActive(true);
            Destroy(gameObject);
        }
        /*if (collision.gameObject.tag == "Player" &&  pM.Dashing == true);
        {
            Destroy(gameObject);
        }*/
        if (collision.gameObject.tag == "invisHero" || collision.gameObject.tag =="Hero_enemy1" ||collision.gameObject.tag =="Hero_enemy2")
        {
            Physics.IgnoreCollision(player.GetComponent<Collider>(),GetComponent<Collider>());
        }
    }
    
}
