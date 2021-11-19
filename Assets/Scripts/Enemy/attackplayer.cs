using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackplayer : MonoBehaviour
{
    [SerializeField]private HealthManager _healthManager;
    [SerializeField]private PlayerMovement _playerMovement;
    public int HurtValue;

    private void Start()
    {
        _healthManager = FindObjectOfType<HealthManager>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            _healthManager.HurtPlayer(HurtValue);
            
            if (other.transform.position.x < transform.position.x)
            {
                _playerMovement.knockbackRight = true;
                _playerMovement.knockbackPlayer();
                _playerMovement.knockbackCount = -_playerMovement.knockbackLength;
            }
            else
            {
                _playerMovement.knockbackRight = false;
                _playerMovement.knockbackPlayer();
                _playerMovement.knockbackCount = -_playerMovement.knockbackLength;
            }
        }
    }
}
