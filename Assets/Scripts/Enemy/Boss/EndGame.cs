using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    
    public GameObject boss_health;
    public GameObject exitDoor;
    public GameObject Dragon;
    public GameObject Human;
    public GameObject FadeUI;
    public Animator Fade;

    private BossHealth _bossHealth;
    // Start is called before the first frame update
    void Start()
    {
        _bossHealth = GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (BossHealth.enemyHealth <= 10)
        {
            StartCoroutine(playAnim());
            Dragon.SetActive(false);
            Human.SetActive(true);
        }
        
        if (BossHealth.enemyHealth <= 0)
        {
            Destroy(gameObject);
            boss_health.SetActive(false);
            exitDoor.SetActive(true);
            
        }
    }


IEnumerator playAnim()
{
    FadeUI.SetActive(true);
    Fade.SetTrigger("Fade");
    yield return new WaitForSeconds(2f);
    Destroy(FadeUI);
}
    public void Shrik()
    {
        
    }
}
