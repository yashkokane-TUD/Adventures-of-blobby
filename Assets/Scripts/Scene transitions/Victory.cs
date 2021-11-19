using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Victory : MonoBehaviour
{
    private PlayerMovement pM;
    //public string SceneToLoad;

    public GameObject playerInitalPosition;
    public bool lvl1Cam;
    [SerializeField] private CinemachineVirtualCamera vCam1;

    [SerializeField] private CinemachineVirtualCamera vCam2;
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //player.transform.position = new Vector3(-2.57f, -3.39f, 0f);
            player.transform.position = playerInitalPosition.transform.position;
            //PlayerStorage.StartPosition = playerInitalPosition;
            //SceneManager.LoadScene(SceneToLoad);
            
            /*pM.Level2 = true;
            pM.Level1 = false;*/
            //pM.onSpawn();
            //if (lvl1Cam)
            
                vCam1.Priority = 8;
                vCam2.Priority = 9;
            
            /*else
            {
                vCam1.Priority = 9;
                vCam2.Priority = 8;
            }*/

            //lvl1Cam = !lvl1Cam; 

        }
    }

}
