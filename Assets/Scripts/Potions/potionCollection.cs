using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class potionCollection : MonoBehaviour
{
     public static int potion_B_Count = 0;
     public static int potion_R_Count = 0;
     
    public static int maxRpotions = 100;
    private static int maxBpotions = 100;

    private PlayerMovement pM;
    
    void Awake()    
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        pM = FindObjectOfType<PlayerMovement>();
        if (SaveManager.instance.hasloaded)
        {
            potion_B_Count = SaveManager.instance.activeSave.potionsB;
            potion_R_Count = SaveManager.instance.activeSave.potionsR;
        }
        else
        {
            potion_B_Count = 0;
            potion_R_Count = 0;
        }
        PotionRManager.SetPotionR(potion_R_Count);
        PotionBManager.SetPotionB(potion_B_Count);
      
    }
  
    
    // Update is called once per frame
    public  static void UpdateRedCount()
    {
        potion_R_Count = potion_R_Count + 20;
        if (potion_R_Count >= maxRpotions)
        {
            potion_R_Count = maxRpotions;
        }
        PotionRManager.SetPotionR(potion_R_Count);

    }
    public static void UpdateBlueCount()
    {
        potion_B_Count = potion_B_Count + 10;
        
        if (potion_B_Count >= maxBpotions)
        {
            potion_B_Count = maxBpotions;
        }
        
        PotionBManager.SetPotionB(potion_B_Count);
    }

    public static void BReduceCount()
    {
        potion_B_Count = potion_B_Count - 2;
        PotionBManager.SetPotionB(potion_B_Count);
        //Debug.Log(potion_B_Count);
    }
    
    public static void RReduceCount()
    {
        if (PlayerMovement.p_E1)
        {
            
            potion_R_Count = potion_R_Count - 35;
            //Debug.Log(potion_R_Count);
            PotionRManager.SetPotionR(potion_R_Count);
            
        }
        else if (PlayerMovement.p_E2)
        {
            //Debug.Log("E2 hit");
            potion_B_Count = potion_R_Count - 75;
            PotionRManager.SetPotionR(potion_R_Count);
        }
        
        //Debug.Log(potion_B_Count);
    }
    
}
