using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    //private Enemy Enemy;
    public Rigidbody2D rbody;
        
        // Start is called before the first frame update
        void Start()
        {
            
        }
        // Update is called once per frame
        void Update()
        {
            rbody.velocity = projectileSpeed * transform.right;
            
            //transform.Translate(transform.right * projectileSpeed * Time.deltaTime,Space.World);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy" ||collision.gameObject.tag == "Enemy_Bot" )
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject, 2f);
            }
        }
}
