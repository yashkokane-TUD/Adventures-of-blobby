using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public PlayerMovement Dash;
    private BossHealth _bossHealth;
    private EndGame _end;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            BossHealth.enemyHealth -= 5;
            //_bossHealth.SetHealth( _bossHealth.enemyHealth);
            //_end.Shrik();
        }
        if (other.gameObject.tag == "Player" && Dash.Dashing)
        {
            BossHealth.enemyHealth -= 1;
            //_bossHealth.SetHealth(_bossHealth.enemyHealth);
            //_end.Shrik();
        }
    }
}
