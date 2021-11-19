using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public int StartLives;

    public static int LifeCounter;

    private TMP_Text theText;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        theText = GetComponent<TMP_Text>();
        if (SaveManager.instance.hasloaded)
        {
            LifeCounter = SaveManager.instance.activeSave.lives;
            
        }
        else
        {
            LifeCounter = StartLives;
        }
        //LifeCounter = StartLives;
      
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeCounter <0)
        { 
            SceneManager.LoadScene("game_over");  
        }
        theText.text = LifeCounter.ToString();;
    }

    /*public void GiveLife()
    {

        LifeCounter++;
        SaveManager.instance.activeSave.lives = LifeCounter;
    }*/

    public void TakeLife()
    {
        LifeCounter--;
       // SaveManager.instance.activeSave.lives = LifeCounter;
    }
}
