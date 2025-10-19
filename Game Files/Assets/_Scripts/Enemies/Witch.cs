using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         //add ui that game is over
      }
   }
}
