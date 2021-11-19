using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private  Vector3 StartPos;
    //public static int score;
    
    private bool gamePaused = false;
    private gameManager Gm;
    private HealthManager _healthManager;
    private static gameManager Instance;
    public GameObject menu;
    
    //public Vector3 resPt;
    private PlayerMovement pM;
   // public GameObject[] BlobArray;
    public GameObject CurrentCheckpoint;
    
    
    /*private LifeManager _lifeManager;
    public GameObject introDialogue;
    private blobs _blobs;
    private SaveManager _saveManager;
    public GameObject player;
    public int lives;
    public closeDialogue cD;
    private checkpoint _checkpoint;
    public GameObject[] GameManagers;*/
    void Awake ()   
    {
        /*if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }*/
    }
    
    
    private void Start()
    {
        SaveManager.instance.Save();
        //BlobArray = GameObject.FindGameObjectsWithTag("Blobs");
        pM = FindObjectOfType<PlayerMovement>();
        _healthManager = FindObjectOfType<HealthManager>();
        //SaveManager.instance.Save();
        /*_lifeManager = FindObjectOfType<LifeManager>();
        cD = FindObjectOfType<closeDialogue>();
        _saveManager = FindObjectOfType<SaveManager>();
        _blobs = FindObjectOfType<blobs>();
        _checkpoint = FindObjectOfType<checkpoint>();*/
        /*GameManagers = GameObject.FindGameObjectsWithTag("GameManager");
        if (GameManagers.Length > 1)
        {
            Destroy(GameManagers[1]);
        }*/
    }
    public void RespawnPlayer()
    {
        pM.transform.position = CurrentCheckpoint.transform.position;
        _healthManager.ResetHealth();
        /*for (int i = 0; i < BlobArray.Length; i++)
        {
            BlobArray[i].SetActive(true);
        }*/
    }
    public void TogglePauseState()
    {
        gamePaused = !gamePaused;
        if (gamePaused)
        {
            UnPauseGame();
        }
        else
        { 
            PauseGame();
        }
    }
     public void PauseGame()
     {
         Time.timeScale = 0;
         menu.SetActive(true);
     }

     public void UnPauseGame()
     {
         Time.timeScale = 1;
         menu.SetActive(false);
     }

     public void RestartGame()
     {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         _healthManager.ResetHealth();
     }

     public void Quit()
     {
         //If we are running in a standalone build of the game
#if UNITY_STANDALONE
         //Quit the application
         Application.Quit();
#endif

         //If we are running in the editor
#if UNITY_EDITOR
         //Stop playing the scene
         UnityEditor.EditorApplication.isPlaying = false;
#endif
     }
     public void QuitGame()
     {
         SceneManager.LoadScene("Menu_Scene");
     }

         
}
