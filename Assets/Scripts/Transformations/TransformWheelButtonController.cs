using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformWheelButtonController : MonoBehaviour
{
    public int ID;
    public string Transform_name;
    private bool selectedTransform = false;

    private TransformationManager tM;
    
    private void Start()
    {
        tM = FindObjectOfType<TransformationManager>();
     
    }

    
    // Update is called once per frame
    void Update()
    {
        
        if (selectedTransform)
        {
          
        }
        
    }
    public void Selected()
    {
        selectedTransform = true;
        TransformationManager.TransformID = ID;
        tM.TransformationData();
        tM.TranformWheel();

    }
}
