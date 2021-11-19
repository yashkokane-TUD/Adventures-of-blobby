using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class activateBoss : MonoBehaviour
{
    public GameObject boss;

    [SerializeField] private GameObject vCam1;

    [SerializeField] private GameObject vCam2;
    [SerializeField] private CinemachineVirtualCamera Cam1;
    //public GameObject boss_health;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            boss.SetActive(true);
            vCam1.SetActive(false);
            vCam2.SetActive(true);
            Cam1.Priority = 10;

        }
    }
}
