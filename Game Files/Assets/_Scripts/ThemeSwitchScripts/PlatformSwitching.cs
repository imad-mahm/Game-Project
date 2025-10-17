using UnityEngine;

public class PlatformSwitching : MonoBehaviour
{
    [SerializeField] private GameObject[] lightPlatforms;
    [SerializeField] private GameObject[] darkPlatforms;

    private void Awake()
    {
        lightPlatforms = GameObject.FindGameObjectsWithTag("Light");
        darkPlatforms = GameObject.FindGameObjectsWithTag("Dark");
    }

    private void OnEnable()
    {
        WorldFlipEvent.OnWorldFlipped += SwitchPlatforms;
    }

    private void OnDisable()
    {
        WorldFlipEvent.OnWorldFlipped -= SwitchPlatforms;
    }

    private void Start()
    {
        foreach (var darkPlatform in darkPlatforms)
            darkPlatform.SetActive(false);
    }

    private void SwitchPlatforms()
    {
        foreach (var darkPlatform in darkPlatforms)
            darkPlatform.SetActive(!darkPlatform.activeSelf);

        foreach (var lightPlatform in lightPlatforms)
            lightPlatform.SetActive(!lightPlatform.activeSelf);
    }
}