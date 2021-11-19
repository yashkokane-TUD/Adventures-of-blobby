using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    //private FinalBoss fB;
    //public GameObject boss_health;
    //public GameObject exit;
   
    public  Slider slider;
    private FinalBoss _finalBoss;
    public static int enemyHealth = 10;
    // Start is called before the first frame update
    void Start()
    {
       // _bossHealth = GetComponent<BossHealth>();
        SetHealth(enemyHealth);
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        SetHealth(enemyHealth);
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;
        
    }
    

    
    
}
