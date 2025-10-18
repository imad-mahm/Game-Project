using UnityEngine;

public class Collecting : MonoBehaviour
{
    public int Count { get; private set; } = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Count++;
            Destroy(other.gameObject);
        }
    }
}
