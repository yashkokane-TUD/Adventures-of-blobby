using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeDialogue : MonoBehaviour
{

    public Button Btn;
    public bool close;
    public  GameObject dialogue;
    public static closeDialogue instance;
    public void CLosedialogue()
    {
        if (!close)
        {
            dialogue.SetActive(false);
        }
        close = true; //store value into save file
        

    }
}
