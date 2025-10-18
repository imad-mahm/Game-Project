using TMPro;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public static int Count;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = "Clock Count: " + Count.ToString();
    }
}
