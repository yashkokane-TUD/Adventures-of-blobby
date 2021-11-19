using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveForce, maxSpeed, jumpForce;
    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private Collider2D groundCheck_B;
    [SerializeField] private LayerMask groundLayers;
    
    [SerializeField] public bool canDash;
    [SerializeField] public bool Dashing;
    public static PlayerMovement pMovement;
    public GameObject MapToggle;
    private bool showMap;
    
    //knockback variables
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockbackRight;

    [SerializeField] public bool canSJ;
    public static float moveDir;
    private Rigidbody2D myRB;
    
    private SpriteRenderer mySR;
    [SerializeField]private SpriteRenderer mySRE;
    
    //public float V_speed;
    public bool canJump;
    
    //animators for the forms of player
    [SerializeField] private Animator anim_Small;
    [SerializeField] private Animator anim_big;
    [SerializeField] private Animator anim_enemy1;
    [SerializeField] private Animator anim_enemy2;
    
    //Transform variables
    //player evolution
    public static bool p_level1;
    public static bool p_level2;
    public static bool p_E1;
    public static bool p_E2;
    
    //Dash Controls
    private float dashSpeed = 25;
    private float dashTime =0;
    private float startDashTime =0.6f;
    private float previousDirection = 1;

    //super jump controls
    public bool _superJump;
    private float chargeUp;

    public bool active;
    
    private Invisiblity invis;
    private potionCollection pC;
    private TransformationManager tM;
    private ShootingBullet sB;
    private gameManager GameManager;
    private HealthManager _hM;
    public GameObject[] players;
    private string sceneName;
    [SerializeField] public Transform startpos;
    
    public AudioSource walkSound;
    public AudioSource DashSound;
    //public AudioSource JumpSound;
    
    private void Awake()
    {
        /*if (pMovement == null)
        {
            DontDestroyOnLoad(gameObject);
            pMovement = this;
        }
        else if (pMovement != this)
        {
            Destroy(gameObject);
        }*/
        
    }
    void Start()
    {
        Time.timeScale = 1;
        anim_Small = GetComponentInChildren<Animator>();
        anim_enemy1 = GetComponentInChildren<Animator>();
        anim_enemy2 = GetComponentInChildren<Animator>();
        myRB = GetComponent<Rigidbody2D>();
        mySR = GetComponentInChildren<SpriteRenderer>();
        dashTime = startDashTime;   //Dash timer
        p_level1 = true;
        invis = FindObjectOfType<Invisiblity>();
        pC = FindObjectOfType<potionCollection>();
        tM = FindObjectOfType<TransformationManager>();
        sB = FindObjectOfType<ShootingBullet>();
        _hM = FindObjectOfType<HealthManager>();

        mySRE = GetComponentInChildren<SpriteRenderer>();
  
        players = GameObject.FindGameObjectsWithTag("PlayerPrefab");
        if (players.Length > 1)
        {
            Destroy(players[1]);
        }
        if (SaveManager.instance.hasloaded)
        {
            transform.position = SaveManager.instance.activeSave.lastCheckPoint;
            
        }
        else
        {
            transform.position = startpos.position;
        }
        //transform.position = startpos.position;
    }
    
    private void FixedUpdate()
    {
        /*evolutionCheck();*/ //to check if the player has reached the evolution stage
        var moveAxis = Vector2.right * moveDir;
        if (Mathf.Abs(myRB.velocity.x) < maxSpeed)
        {
            myRB.AddForce(moveAxis * moveForce, ForceMode2D.Force);
        }

        if (tM.HeroBig)
        {
            p_level1 = false;
            p_level2 = true;
        }
        if (p_level1)
        {
            canJump = groundCheck.IsTouchingLayers(groundLayers);       //Ground check for small form 
            if (!canJump)
            {
                //Debug.Log("hit1");
                anim_Small.SetBool("isGrounded", false);
            }
            else
            {
                anim_Small.SetBool("isGrounded", true);
            }
            
        }
        else if (p_level2)
        {
            canJump = groundCheck_B.IsTouchingLayers(groundLayers);       //Ground check for final form 
            if (!canJump)
            {
                //Debug.Log("hit1");
                anim_big.SetBool("isGrounded", false);
            }
            else
            {
                anim_big.SetBool("isGrounded", true);
            }

        }
        if (myRB.velocity.x != 0)
        {
            previousDirection = myRB.velocity.x;
        }

        if (knockbackCount == knockbackLength)     
        {
            knockbackPlayer();
        }
        else
        {
            knockbackCount = 0;
        }
        
    }
    public void sizeupdate()
    {
        if (p_level1)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.939f,1.275f);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2 (0.107f, 0.074f);
        }
        else if(p_level2)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(-1.198f,3.349f);
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2 (-1.198f, 4.531f);
        }
    }
    
    
    public void Move(InputAction.CallbackContext context)
    {
        if (!_hM.isDead)        //movement stopped if player is dead
        {
            if (knockbackCount <= 0)
            {
              moveDir = context.ReadValue<float>();
                if (p_level1)
                {
                    if (moveDir >0)
                    {
                        transform.localRotation = Quaternion.Euler(0, 0, 0);
                        anim_Small.SetBool("IsMoving",true);
                        if (!walkSound.isPlaying)
                        {
                            walkSound.Play();
                        }
                        
                    }
                    else if (moveDir < 0)
                    { 
                        transform.localRotation = Quaternion.Euler(0, 180, 0);
                        anim_Small.SetBool("IsMoving",true);
                        //walkSound.Play();
                        if (!walkSound.isPlaying)
                        {
                            walkSound.Play();
                        }
                    }
                    else
                    {
                        anim_Small.SetBool("IsMoving",false);
                        walkSound.Stop();
                    }
                }       
                else if(p_level2)
                {
                    if (moveDir >0)
                    {
                        transform.localRotation = Quaternion.Euler(0, 0, 0);
                        anim_big.SetBool("IsMoving",true);
                        walkSound.Play();
                    }
                    else if (moveDir < 0)
                    {
                        transform.localRotation = Quaternion.Euler(0, 180, 0);
                        anim_big.SetBool("IsMoving",true);
                        walkSound.Play();
                    }
                    else
                    {
                        anim_big.SetBool("IsMoving",false);
                        walkSound.Stop();
                    }
                }
                else if (p_E1)
                {
                    if (moveDir >0)
                    {
                        mySRE.flipX = false;
                        anim_enemy1.SetBool("IsMoving",true);
                        Debug.Log("hit");
                    }
                    else if (moveDir < 0)
                    {
                        mySRE.flipX = true;
                        anim_enemy1.SetBool("IsMoving",true);
                        Debug.Log("hit1");
                    }
                    else
                    {
                        anim_enemy1.SetBool("IsMoving",false);
                    }
                }
                else if (p_E2)
                {
                    if (moveDir >0)
                    {
                        mySR.flipX = false;
                        anim_enemy2.SetBool("IsMoving",true);
                    }
                    else if (moveDir < 0)
                    {
                        mySR.flipX = true;
                        anim_enemy2.SetBool("IsMoving",true);
                        
                    }
                    else
                    {
                        anim_enemy2.SetBool("IsMoving",false);
                    }
                }  
            }
        }
       
    }

    public void knockbackPlayer()        //knockback handler
    {
        if (knockbackRight)
        {
            myRB.velocity = new Vector2(-knockback, 0f);
        }

        if (!knockbackRight)
        {
            myRB.velocity = new Vector2(knockback, 0f);
        }

        knockbackCount -= Time.deltaTime;
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
       
        if (canJump && context.started)
        {
            Jump();
        }
        
        if (context.canceled && myRB.velocity.y > 0)
        {
                myRB.velocity = new Vector2(myRB.velocity.x, 0f);
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (p_level1)
            {
               if (canDash && !Dashing && moveDir!= 0)
               {
                    if (dashTime <= 0)
                    {
                        dashTime = startDashTime;
                        myRB.velocity = Vector2.zero;
                        Dashing = false;
                    }
                    else
                    {
                        Dashing = false;
                        dashTime -= Time.deltaTime;
                        if (myRB.velocity.x < 0)
                        {
                            if (p_level1)
                            {
                                anim_Small.SetBool("isDashing", true);
                                DashSound.Play();
                                Invoke("Dashtimer", 1.0f); 
                                myRB.velocity = Vector2.left * dashSpeed;
                                Dashing = true;
                            }
                            else if (p_level2)
                            {
                                anim_big.SetBool("isDashing",true);
                                DashSound.Play();
                                Invoke("Dashtimer", 1.0f); 
                            }
                            
                        }
                        else if (myRB.velocity.x > 0)
                        {
                            myRB.velocity = Vector2.right * dashSpeed;
                            Dashing = true;
                            if (p_level1)
                            {
                                anim_Small.SetBool("isDashing",true);
                                DashSound.Play();
                                //anim_Small.Play("Hero1_Dash");
                                Invoke("Dashtimer", 1.0f); 
                            }
                            else if (p_level2)
                            {
                                anim_big.SetBool("isDashing",true);
                                DashSound.Play();
                                Invoke("Dashtimer", 1.0f); 
                            }
                        }
                        else
                        {
                            if(previousDirection < 0) myRB.velocity = Vector2.left * dashSpeed;
                            if(previousDirection > 0) myRB.velocity = Vector2.right * dashSpeed;
                           
                            Dashing = true;
                            Invoke("Dashtimer", 1.0f);
                        }
                    }
               } 
            }
            
        }
        else
        {
            if (p_level1)
            {
                anim_Small.SetBool("isDashing",false);
                anim_Small.SetBool("IsIdle",true);
            }
            else if (p_level2)
            {
                anim_big.SetBool("isDashing",false);
                anim_big.SetBool("IsIdle",true);
            }
        }
    }
   void Dashtimer()
   {
       Dashing = false;
       anim_Small.SetBool("isDashing",false);
   }
   
   public void SuperJump(InputAction.CallbackContext context)
   {
       if (context.started && canSJ )
       {
           chargeUp = jumpForce * 0.08f;
           if (p_level1)
           {
               if (canJump)
               {
                   myRB.AddForce(transform.up * jumpForce * chargeUp , ForceMode2D.Impulse );
                   canJump = false;
                   //JumpSound.Play();
                   anim_Small.SetTrigger("Takeoff");
                   anim_Small.SetBool("isJumping", true);
                   chargeUp = 0f;
               }
               else
               {
                   anim_Small.Play("Hero1_idle");
               }
           }
           else if (p_level2)
           {
               if (canJump)
               {
                   myRB.AddForce(transform.up * jumpForce * chargeUp*2f, ForceMode2D.Impulse);
                   canJump = false;
                   //JumpSound.Play();
                   anim_big.SetTrigger("Takeoff");
                   anim_big.SetBool("isJumping", true);  
               }
               else
               {
                   anim_Small.Play("Hero2_Idle");
               }
           }
           Debug.Log(chargeUp);
           
       }
       
   }
   
   public void heroInvis(InputAction.CallbackContext context) //invisibility trigger function
   {
       if (context.started)
       {
           if (potionCollection.potion_B_Count >= 30)
           {
               active = !active;
               invis.heroInvis();
           }
       }
   }
   public void transform_hero(InputAction.CallbackContext context) //transformation trigger function
   {
       if (context.started)
       {
           
           tM.TranformWheel();
       }
   }
    public void Jump()
    {
        if (p_level1)
        {
            if (canJump)
            {
                anim_Small.SetTrigger("Takeoff");
                anim_Small.SetBool("isJumping", true);
                //JumpSound.Play();
                myRB.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                canJump = false;
            } 
            else if (!canJump)
            {
                anim_Small.SetBool("isJumping", false);
            }
        }
        else if (p_level2)
        {
            if (canJump)
            {
                anim_big.SetTrigger("Takeoff");
                anim_big.SetBool("isJumping", true);
                //JumpSound.Play();
                myRB.AddForce(transform.up * jumpForce * 1.2f, ForceMode2D.Impulse);
                canJump = false;  
            }
            else if (!canJump)
            {
                anim_big.SetBool("isJumping", false);
            }
        }
    }
    
   
    public void Map(InputAction.CallbackContext context) //map trigger
    {
        if (context.started)
        {
            ShowMap();
            MapDisplay();
        }
    }

    void ShowMap()
    {
        showMap = !showMap;
    }

    void MapDisplay()
    {
        if (showMap)
        {
            MapToggle.SetActive(true);

        }
        else
        {
            MapToggle.SetActive(false);
        }
    }

    public void Shoot(InputAction.CallbackContext context)      //Shoot trigger
    {
        if (context.started)
        {
            if (p_level1)
            {
                anim_Small.Play("Hero1_shoot");
                sB.CheckToShoot();
            }
            else if (p_level2)
            {
                anim_big.Play("Hero2_shoot");
                sB.CheckToShoot();
            }
        }
    }
}
