using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitching : MonoBehaviour
{
    public static PlatformSwitching Instance;
    [SerializeField] private GameObject[] lightPlatforms;
    [SerializeField] private GameObject[] darkPlatforms;
   
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        lightPlatforms = GameObject.FindGameObjectsWithTag("Light");
        darkPlatforms = GameObject.FindGameObjectsWithTag("Dark");
    }
    void Start()
    {
        foreach (var darkPlatform in darkPlatforms)
        {
            darkPlatform.SetActive(false);
        }
        foreach (var p in lightPlatforms) p.SetActive(true);
        foreach (var p in darkPlatforms) p.SetActive(false);
    }


    public void SwitchPlatforms()
    {
        foreach (var darkPlatform in darkPlatforms)
        {
            darkPlatform.SetActive(!darkPlatform.activeInHierarchy);
        }

        foreach (var lightPlatform in lightPlatforms)
        {
            lightPlatform.SetActive(!lightPlatform.activeInHierarchy);
        }
    }
}
