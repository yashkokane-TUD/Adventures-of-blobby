using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //public static HealthManager Hmanager;
    public static int PlayerHP;
    public int healthMax = 100;
    public HealthBar healthbar;
    public bool isDead = false;
    public static HealthManager instance;
    public GameObject HealthBar;
 
   // private gameManager LevelManager;
    private LifeManager lifeSystem;
    private potionCollection pC;
    private gameManager gM;
    private checkpoint Cp;
    public Animator anim;
    void Awake()    
    {
        //DontDestroyOnLoad(gameObject);
        /*
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    */
    }
   
    // Start is called before the first frame update
    void Start()
    {
        healthbar = FindObjectOfType<HealthBar>();
        healthbar.SetMaxHealth(); //sets the max possible health in the HUD
        lifeSystem = FindObjectOfType<LifeManager>();
        //LevelManager = FindObjectOfType<levelManager>();
        gM = FindObjectOfType<gameManager>();
        pC = FindObjectOfType<potionCollection>();
        Cp = FindObjectOfType<checkpoint>();
        //PlayerHP = 12;
        if (SaveManager.instance.hasloaded)
        {
            PlayerHP = SaveManager.instance.activeSave.HP;
            Debug.Log(PlayerHP);
        }
        else
        {
            PlayerHP = 12;
        }
        
        healthbar.SetHealth(PlayerHP);

        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (PlayerHP <= 0 && !isDead)
        {
            PlayerHP = 0;
            gM.RespawnPlayer();
            lifeSystem.TakeLife();
            isDead = true;
            
        }
        else
        {
            isDead = false;
        }
        //StatsStorage.HP = PlayerHP;
    }
    
    public void updateHealth()
    {
        if (PlayerHP >= healthMax)
        {
            PlayerHP = healthMax;
        }
        else
        {
            PlayerHP = PlayerHP + 3;
           
        }
        
        healthbar.SetHealth(PlayerHP);
    }
    
    public void updateHealthOnAttack()
    {
        PlayerHP = PlayerHP - 2;
        Debug.Log(PlayerHP);
        healthbar.SetHealth(PlayerHP);
        
    }

    public void ResetHealth()
    {
        PlayerHP = Cp.playerHPatCheck;
        PlayerHP = PlayerHP + 5;
        healthbar.SetHealth(PlayerHP);
        isDead = false;
        //PlayerPrefs.SetInt("PlayerHP", PlayerHP + 20);
    }

    public void HurtPlayer(int Damage)
    {
        PlayerHP -= Damage;
        healthbar.SetHealth(PlayerHP);
    }

    public void shootHealthLoss()
    {
        PlayerHP = PlayerHP - 1;
        healthbar.SetHealth(PlayerHP);
    }
}
