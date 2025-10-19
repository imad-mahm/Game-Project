using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieKillzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            Destroy(other.gameObject,1.25f);
            //add wait until animation is done if not the 1.25f is almost perfect
        }
    }
}
