using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionRManager : MonoBehaviour
{
    
   // public Slider slider;
    public static int potionMaxValue = 100;
    
    [SerializeField]private static TMP_Text theTextR;
    // Start is called before the first frame update
    void Start()
    {
        theTextR = GetComponent<TMP_Text>();
        SetMaxPotionsR();
  
            /*if (SaveManager.instance.saveExists)
            {
               SetPotionR(SaveManager.instance.activeSave.potionsR);
            }*/

        
        
    }
  
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetMaxPotionsR()
    {
        //slider.maxValue = 100;
    }
    public static void SetPotionR(int potion)
    {
        if (potion >= potionMaxValue)
        {
            potion = potionMaxValue;
        }
        theTextR.text = potion.ToString();
    }
}
