using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
   
    public void PlayGame()
    {
       
        /*SceneManager.LoadScene("level-1");
        SaveManager.instance.DeleteSave();*/
    }

    /*public void RestartGame()
    {
        HealthManager.PlayerHP = 15;
        SceneManager.LoadScene("level-1");  
    }*/
    public void Quit()
    {
        SceneManager.LoadScene("Menu_Scene");
    }
}
