using UnityEngine;

public class Collecting : MonoBehaviour
{
    [SerializeField] private float clipDuration = 3.5f; // play first 3.5 seconds

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            AudioSource source = other.GetComponent<AudioSource>();

            if (source != null && source.clip != null)
            {
                // Create a temporary object to play the sound
                GameObject tempAudio = new GameObject("TempAudio");
                AudioSource tempSource = tempAudio.AddComponent<AudioSource>();

                // Copy settings from the original AudioSource
                tempSource.clip = source.clip;
                tempSource.volume = source.volume;
                tempSource.pitch = source.pitch;
                tempSource.spatialBlend = source.spatialBlend; // keeps 2D/3D behavior
                tempSource.transform.position = source.transform.position;

                // Play and destroy after desired duration
                tempSource.Play();
                Destroy(tempAudio, clipDuration);
            }

            // Increase count and remove collectable
            Collectables.Count++;
            Destroy(other.gameObject);
        }
    }
}