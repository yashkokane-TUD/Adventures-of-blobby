using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreballMovement : MonoBehaviour
{
    [SerializeField] private Vector2 projectileSpeed;
    //private Enemy Enemy;
    public Rigidbody2D rbody;
    private HealthManager _healthManager;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        _healthManager = GetComponent<HealthManager>();
    }
    // Update is called once per frame
    void Update()
    {
        rbody.velocity = projectileSpeed;
        Destroy(gameObject, 3f);
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            _healthManager.HurtPlayer(5);
            //Debug.Log("player hit");
        }
        else
        {
            Destroy(gameObject, 3f);
        }
        
        if (collision.gameObject.tag == "invisHero" || collision.gameObject.tag =="Hero_enemy1" ||collision.gameObject.tag =="Hero_enemy2")
        {
            Physics.IgnoreCollision(player.GetComponent<Collider>(),GetComponent<Collider>());
        }
    }
}
