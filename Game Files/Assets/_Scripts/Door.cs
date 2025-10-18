using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject popup; 
    //[SerializeField] private Collecting playerCollecting;

    private void Start()
    {
        popup?.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player entered door");
            //if (playerCollecting != null)
            //{
                //Debug.Log("Player has collected " + playerCollecting.Count + " items");
                if ( Collectables.Count >= 3)
                {
                    SceneManager.LoadScene(2);
                }
                else
                {
                    popup?.SetActive(true);
                }
           // }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popup?.SetActive(false);
        }
    }
}