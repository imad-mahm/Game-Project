using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collecting : MonoBehaviour
{
    [SerializeField] private int count;

    private void Awake()
    {
        count = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            count++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Door") && count == 3)
        {
            SceneManager.LoadScene("Level 2(escape Asylum)");
        }
    }
}
