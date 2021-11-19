using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobs : MonoBehaviour
{
    private HealthManager _healthManager;
    public static blobs instance;
    [SerializeField] 
    public bool Collected;

    public int ID;
    public AudioClip batterySound;
    private levelManager lm;
    // Start is called before the first frame update
    private void Awake()
    {
        /*if (Collected)
        {
            gameObject.SetActive(false);
        }*/
    }

    void Start()
    {
        /*if (!Collected)
        {
            Collected = false;
        }*/
        lm = FindObjectOfType<levelManager>();
        _healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Collected)
        {
            gameObject.SetActive(true);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(batterySound, transform.position, 1);
            _healthManager.updateHealth();
            Collected = true;
            gameObject.SetActive(false);
            lm.blobsList.Add(ID); 
            /*Destroy(gameObject);*/
        }
    }

    public void respawnBlobs()
    {
        if (Collected)
        {
           
            gameObject.SetActive(true);
            Collected = false;
        }
        
    }
}
