using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TransformationManager : MonoBehaviour
{
    private potionCollection PC;
    private PlayerMovement pM;
    
    public GameObject transformWheel;
    public GameObject HSmall;
    public GameObject HBig;
    public GameObject H_E1;
    public GameObject H_E2;
    public bool canTransform;
    public static int TransformID = 0;
    public bool show;
    private bool transformed;

    public Animator anim_s;
    public Animator anim_b;

    public bool HeroBig;
    [SerializeField] float startTime = 10;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        pM = FindObjectOfType<PlayerMovement>();
        PC = FindObjectOfType<potionCollection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthManager.PlayerHP < 50)
        {
            canTransform = false;
            transformCheck();
        }
        else
        {
            canTransform = true;
        }

        if (transformed)
        {
            startTimer();
        }
    }

    public void transformCheck()
    {
        if (!canTransform && !transformed)
        {
            HSmall.SetActive(true);
            HBig.SetActive(false);
            pM.moveForce = 25;
            PlayerMovement.p_level1 = true;
            PlayerMovement.p_level2 = false;
        }
    }
    public void TranformWheel()
    {
        show = !show;
        if (show)
        {
            //Debug.Log("hit");
            transformWheel.SetActive(true);
            TransformID = 0;
        }
        else
        {
            transformWheel.SetActive(false);
        }
    }
    
    public void TransformationData(){
        //Debug.Log(TransformID);
        switch (TransformID)
        {
            case 0: //nothing selected
                break;
            case 1:
                //Debug.Log("small");
                anim_s.SetTrigger("Evolve");
                pM.Jump();
                HSmall.SetActive(true);
                HBig.SetActive(false);
                H_E1.SetActive(false);
                H_E2.SetActive(false);
                pM.moveForce = 30;
                PlayerMovement.p_level1 = true;
                PlayerMovement.p_level2 = false;
                PlayerMovement.p_E1 = false;
                PlayerMovement.p_E2 = false;
                HeroBig = false;
                //pM.sizeupdate();
                break;
            case 2:
                if (canTransform)
                {
                    anim_b.SetTrigger("Evolution");
                    pM.Jump();
                    HBig.SetActive(true);
                    HSmall.SetActive(false);
                    H_E1.SetActive(false);
                    H_E2.SetActive(false);
                    
                    pM.moveForce = 35;
                    PlayerMovement.p_level1 = false;
                    PlayerMovement.p_level2 = true;
                    PlayerMovement.p_E1 = false;
                    PlayerMovement.p_E2 = false;
                    HeroBig = true;
                }
                //Debug.Log("big");
                //pM.sizeupdate();
                
                break;
            case 3:
                transformed = true;
                //PotionUsage(25);
                HSmall.SetActive(false);
                HBig.SetActive(false);
                H_E1.SetActive(true);
                H_E2.SetActive(false);
                pM.Jump();
                pM.moveForce = 30;
                //Debug.Log("E1");
                gameObject.tag = "Player";
                PlayerMovement.p_level1 = false;
                PlayerMovement.p_level2 = false;
                PlayerMovement.p_E1 = true;
                PlayerMovement.p_E2 = false;
                potionCollection.RReduceCount();
                timer = 10;
                SetTimer();
                break;
            case 4:
                transformed = true;
                //Debug.Log("E2");
                //PotionUsage(50);
                H_E1.SetActive(true);
                H_E2.SetActive(false);
                HBig.SetActive(false);
                HSmall.SetActive(false);
                pM.Jump();
                
                gameObject.tag = "Player";
                PlayerMovement.p_level1 = false;
                PlayerMovement.p_level2 = false;
                PlayerMovement.p_E1 = false;
                PlayerMovement.p_E2 = true;
                potionCollection.RReduceCount();
                timer = 5;
                SetTimer();
                break;
        }
    }
    public void startTimer()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0)
        {
            if (HealthManager.PlayerHP < 50)
            {
                TransformID = 1;
                TransformationData();
                transformed = false;
            }
            else if (HealthManager.PlayerHP > 50)
            {
                TransformID = 2;
                TransformationData();
                transformed = false;
            }
            
        }
    }
   
    public void SetTimer()
    {
        timer = startTime;
    }
   
}
