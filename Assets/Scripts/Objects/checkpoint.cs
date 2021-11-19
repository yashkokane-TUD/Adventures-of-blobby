using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private levelManager LevelManager;
    private gameManager gM;
    
    public int playerHPatCheck;
    public SpriteRenderer SR;
    public Sprite sprite;
    private string value;

    public GameObject light;
    
    //public GameObject[] blobs;
    //private blobs Blob;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponentInChildren<SpriteRenderer>();
        gM = FindObjectOfType<gameManager>();
        LevelManager = FindObjectOfType<levelManager>();
        //Blob = FindObjectOfType<blobs>();
        //blobs = GameObject.FindGameObjectsWithTag("Blobs");
        //blobs = GameObject.FindGameObjectsWithTag("Blobs");
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SR.sprite = sprite;
            light.SetActive(true);
            gM.CurrentCheckpoint = gameObject;  //save current checkpoint into var for respawn data at checkpoints
            playerHPatCheck = HealthManager.PlayerHP; //save player Hp into var for respawn data at checkpoints
            saveData();
            
            //Debug.Log(playerHPatCheck);
            /*SaveManager.instance.activeSave.resPos = transform.position;
            SaveManager.instance.Save();*/
        }
    }

 
    public void saveData() //save game data at checkpoints
    {
        SaveManager.instance.activeSave.lives = LifeManager.LifeCounter;
        SaveManager.instance.activeSave.lastCheckPoint = gameObject.transform.position;
        SaveManager.instance.activeSave.HP = HealthManager.PlayerHP;
        SaveManager.instance.activeSave.potionsB = potionCollection.potion_B_Count;
        SaveManager.instance.activeSave.potionsR = potionCollection.potion_R_Count;
        SaveManager.instance.overwriteSave();
    }
    
}
