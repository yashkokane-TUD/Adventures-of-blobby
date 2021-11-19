using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionBManager : MonoBehaviour
{
    
    //public Slider slider;

    public static int potionMaxValue = 100;

    [SerializeField]private  static  TMP_Text theTextB;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        theTextB = GetComponent<TMP_Text>();
        SetMaxPotionsB();
        
            /*if (SaveManager.instance.saveExists)
            {
                //if (SaveManager.instance.hasloaded)
                    SetPotionB(SaveManager.instance.activeSave.potionsB);
            }*/
       
        
    }

   
    public void SetMaxPotionsB()
    {
       // slider.maxValue = 100;
        
    }
    public static void SetPotionB(int potion)
    {
        if (potion >= potionMaxValue)
        {
            potion = potionMaxValue;
        }
        //slider.value = potion;
        theTextB.text = potion.ToString();
    }
}
