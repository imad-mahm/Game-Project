using UnityEngine;

public class Collecting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Collectables.Count++;
            Destroy(other.gameObject);
        }
    }
}
