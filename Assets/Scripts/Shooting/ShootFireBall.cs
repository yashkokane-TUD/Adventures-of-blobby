using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireBall : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
   public Animator anim;
    /*float fireRate = 1f;
    float nextFire;*/
    private bool firing;
    [SerializeField]
    private GameObject shootpt;
    public float startTime;
    public float timer;
    public bool canShoot;
    public bool isShooting;
    public bool dragon;


    public void Update()
    {
        shootCheck();
        if (canShoot)
        {
            startTimer();
        }

        if (timer <=0)
        {
            CheckToShoot();
        }
        
    }
   
    public void CheckToShoot()
    {
        //canShoot = true;
        if (canShoot && !isShooting )
        {
            SetTimer();
            StartCoroutine(MyMethod());
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
            yield return new WaitForSeconds(3f);
            canShoot = false;
            anim.Play("FIre");
            Instantiate(Bullet,shootpt.transform.position, transform.rotation);
            isShooting = true;
        }
    }
    public void SetTimer()
    {
        timer = startTime;
    }
}
