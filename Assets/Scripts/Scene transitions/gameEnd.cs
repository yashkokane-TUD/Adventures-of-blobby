 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

 public class gameEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Hero_enemy1" || other.gameObject.tag == "Hero_enemy2" || other.gameObject.tag == "invisHero")
        {
            SceneManager.LoadScene("victory");
        }
    }
}
