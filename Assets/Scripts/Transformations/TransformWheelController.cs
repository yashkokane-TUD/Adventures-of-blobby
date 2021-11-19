using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformWheelController : MonoBehaviour
{
    [SerializeField]  Button buttonBig;
    [SerializeField]  Button buttonE1;
    [SerializeField]  Button buttonE2;

    [SerializeField] private GameObject textB;
    [SerializeField] private GameObject textE1;
    [SerializeField] private GameObject textE2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthManager.PlayerHP >= 50)
        {
            buttonBig.interactable = true;
            textB.SetActive(false);
        }
        else
        {
            buttonBig.interactable = false;
            textB.SetActive(true);

        }

        if (potionCollection.potion_R_Count > 35)
        {
            buttonE1.interactable = true;
            textE1.SetActive(false);
        }
        else
        {
            buttonE1.interactable = false;
            textE1.SetActive(true);
        }

        if (potionCollection.potion_R_Count > 75)
        {
            buttonE2.interactable = true;
            textE2.SetActive(false);
        }
        else
        {
            buttonE2.interactable = false;
            textE2.SetActive(true);
        }
    }
    
}
