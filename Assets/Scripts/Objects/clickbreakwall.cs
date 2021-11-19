using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class clickbreakwall : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    
        private float pointerDownTimer;
    
        public float holdTime;
    
        public UnityEvent onLongClick;
    
        [SerializeField] private Image fillImage;

        public SpriteRenderer sprite;
        
        Color m_NewColor;
        
        //public GameObject DestBars;
        public DestroyBars dB;
        private void Start()
        {
            sprite = GetComponentInChildren<SpriteRenderer>();
            dB = FindObjectOfType<DestroyBars>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            pointerDown = true;
            
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            Reset();
        }
    
        private void Update()
        {
            if (pointerDown)
            {
                pointerDownTimer += Time.deltaTime;
                if (pointerDownTimer >= holdTime)
                {
                    if (onLongClick != null)
                    {
                        onLongClick.Invoke();
                    }
                    Reset();
                }
                fillImage.fillAmount = pointerDownTimer / holdTime;
            }
        }

        /*public void Change(Sprite differentSprite)
        {
            //Debug.Log("hit");
            //sprite.sprite  = differentSprite; sets sprite renderers sprite
            //dB.destroyPrison();
        }*/
        
        
    
        private void Reset()
        {
            pointerDown = false;
            pointerDownTimer = 0;
            fillImage.fillAmount = pointerDownTimer / holdTime;
            
        }
}
