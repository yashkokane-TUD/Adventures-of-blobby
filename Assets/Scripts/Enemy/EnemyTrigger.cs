using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject Dialogue;
        // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Dialogue.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                Dialogue.SetActive(false);
            }
        }
}
