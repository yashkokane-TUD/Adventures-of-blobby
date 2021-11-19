using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_floor : MonoBehaviour
{
    public PlayerMovement Dash;

    public ParticleSystem particles;

    public ParticleSystem smoke;

    private SpriteRenderer mySR;

    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        mySR = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Dash.Dashing)
            {
                smoke.Play();
                StartCoroutine(Break());
            }
        }
    }
    IEnumerator Break()
    {
        /*yield return new WaitForSeconds(smoke.main.startLifetime.constantMax);
        particles.Play();*/
        
        yield return new WaitForSeconds(smoke.main.startLifetime.constantMax);
        //mySR.enabled = false;
        //bc.enabled = false;
        
        Destroy(gameObject);
    }
}


