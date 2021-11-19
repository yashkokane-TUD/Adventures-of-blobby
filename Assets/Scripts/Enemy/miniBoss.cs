using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class miniBoss : MonoBehaviour
{
    [SerializeField]public float speed;
    //public float range;
    [SerializeField]int enemyHealth;
    public PlayerMovement Dash; 
    //public float minDistance = 2f;
    public Slider slider;
    public static miniBoss instance;
    public GameObject _enemy;
    public Transform[] points;
    public Transform currentPosition;
    public int pointSelect;
    public SpriteRenderer sR;
    public GameObject player;
    public GameObject boss_health;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, currentPosition.position,
            speed * Time.deltaTime);

        if (_enemy.transform.position == currentPosition.position)
        {
            pointSelect++;
            transform.Rotate(new Vector3(0, 180, 0));
            sR.flipX = false;
            if (pointSelect == points.Length)
            {
                pointSelect = 0;
                //sR.flipX = true;
                transform.Rotate(new Vector3(0, 0, 0));
            }

            //sR.flipX = false;
            currentPosition = points[pointSelect];
        }
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            boss_health.SetActive(false);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            enemyHealth -= 2;
            setHealth(enemyHealth);
        }
        if (other.gameObject.tag == "Player" && Dash.Dashing)
        {
            enemyHealth -= 1;
            setHealth(enemyHealth);
        }
        if (other.gameObject.tag == "invisHero")
        {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    private void setHealth(int health)
    {
            slider.value = health;

    }

   
}

