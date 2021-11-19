using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
   // public Animator anim_S;
    /*float fireRate = 1f;
    float nextFire;*/
    [SerializeField]
    private GameObject shootpt;
   
    public float startTime = 5;
    public float timer = 5;

    public bool canShoot;
    public bool isShooting;

    public GameObject shootpointS;
    public GameObject shootpointB;
    private HealthManager hM;
    private PlayerMovement pM;
    
    private void Start()
    {
        //anim_S = GetComponent<Animator>();
        hM = FindObjectOfType<HealthManager>();
        pM = FindObjectOfType<PlayerMovement>();
    }

    public void Update()
    {
        shootCheck();
        if (canShoot)
        {
            startTimer();
        }
    }
   
    public void CheckToShoot()
    {
        if (PlayerMovement.p_level2)
        {
            transform.position = shootpointB.transform.position;
        }
        else
        {
            transform.position = shootpointS.transform.position;
        }
        canShoot = true;
        if (canShoot && !isShooting )
        {
            
            //Debug.Log("shooting");
            SetTimer();
            StartCoroutine(MyMethod());
            hM.shootHealthLoss();
            isShooting = true; 
        }
        else
        {
            timer = startTime;
            isShooting = false;
            
        }
    }

    public void shootCheck()
    {
        if (timer >= 0)
        {
            canShoot = true;
        }
        else if (isShooting)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }
    }

    public void startTimer()
    {
             
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
    }
    
    
    IEnumerator MyMethod() {
        
        if ( timer !=0)
        {
            canShoot = false;
            Instantiate(Bullet, transform.position, transform.rotation);
            isShooting = true;
            yield return new WaitForSeconds(5f);
        }
        isShooting = false;
        canShoot = true;
    }

    public void SetTimer()
    {
        timer = startTime;
    }
    
 
    
}
