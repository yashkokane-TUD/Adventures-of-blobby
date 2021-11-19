using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackedHero : MonoBehaviour
{
    private HealthManager _healthManager;

    //public Animator anim;
    private void Start()
    {
        _healthManager = FindObjectOfType<HealthManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //anim.Play("Enemy_attack");
            _healthManager.updateHealthOnAttack();
            StartCoroutine(attackHalt());
            
            /*Destroy(gameObject);*/
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //anim.Play("Enemy_walk");
    }

    IEnumerator attackHalt()
    {
        yield return new WaitForSeconds(3f);
    }
}
