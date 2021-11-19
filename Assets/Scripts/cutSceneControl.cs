using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class cutSceneControl : MonoBehaviour
{
    [SerializeField] private GameObject vCam1;

    [SerializeField] private GameObject vCam2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            MyMethod();
            //gameObject.SetActive(false);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            vCam1.SetActive(true);
            vCam2.SetActive(false);
        }

    }
    public void MyMethod() 
    {
        vCam2.SetActive(true);
        vCam1.SetActive(false);
        //yield return new WaitForSeconds(3f);
        
        
    }
}
