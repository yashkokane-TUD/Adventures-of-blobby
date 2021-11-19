using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LevelBack : MonoBehaviour
{
    private PlayerMovement pM;
    //public string SceneToLoad;
    public GameObject player;

    public GameObject playerInitalPosition;
    //public Vector2 playerStartPosition;
    
    public bool lvl2Cam;
    [SerializeField] private CinemachineVirtualCamera vCam1;
    [SerializeField] private CinemachineVirtualCamera vCam2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.position = playerInitalPosition.transform.position;
            vCam2.Priority = 8;
            vCam1.Priority = 9;
     

        }
    }
 
}
