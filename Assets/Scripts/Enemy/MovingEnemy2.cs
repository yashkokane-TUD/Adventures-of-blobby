using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MovingEnemy2 : MonoBehaviour
{
    public GameObject _enemy;
    
    //enemy stats
    private float moveSpeed = 3;
    public  int health = 4;

    public Animator anim;
    //enemy patrolling control variables
    public Transform currentPosition;
    public Transform[] points;
    public int pointSelect;
    
    //invoke to check Player dash ability access
    public PlayerMovement Dash; 
    
    public  GameObject item;
    private SpriteRenderer mySR;    //Enemy sprite access
    public GameObject player;
   
    //camera objects
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponentInChildren<SpriteRenderer>();
        currentPosition = points[pointSelect];
        
        //DItems = FindObjectOfType<DropMultipleItems>();
    }

    // Update is called once per frame
    void Update()
    {
        //patrolling enemy code that checks the patrol points assigned to it and flips sprite as per direction
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, currentPosition.position,
            moveSpeed * Time.deltaTime);

        if (_enemy.transform.position == currentPosition.position)
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Dash.Dashing || other.gameObject.tag == "Bullet")
        {
            Debug.Log(health);
            health = health - 1;
    
            if (health == 0)
            {
                item.SetActive(true);
                Destroy(gameObject);
            }
        }
        if (other.gameObject.tag == "invisHero" || other.gameObject.tag =="Hero_enemy1" ||other.gameObject.tag =="Hero_enemy2")
        {
            Physics.IgnoreCollision(player.GetComponent<Collider>(),GetComponent<Collider>());
        }
    }
    
}
