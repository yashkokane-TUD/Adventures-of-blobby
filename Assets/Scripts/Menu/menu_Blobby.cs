using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_Blobby : MonoBehaviour
{
   public Animator anim;

   private void Start()
   {
      anim.Play("Hero1_jump");
   }
}
