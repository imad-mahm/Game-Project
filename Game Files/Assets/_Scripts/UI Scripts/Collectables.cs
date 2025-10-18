using TMPro;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    [SerializeField] private Collecting playerCollecting;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = "Coin Count: " + playerCollecting.Count.ToString();
    }
}
