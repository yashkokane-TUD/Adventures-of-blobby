using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBars : MonoBehaviour
{
    [SerializeField] private GameObject BrokenDoor;
    [SerializeField] private GameObject Door;
    public static bool DoorOff;
    public AudioClip batterySound;

    private void Start()
    {
   
    }
    public void destroyPrison()
    {
        Door.SetActive(false);
        AudioSource.PlayClipAtPoint(batterySound, transform.position, 1);
        BrokenDoor.SetActive(true);
        DoorOff = true;

    }
}