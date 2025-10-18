using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUICanvas : MonoBehaviour
{
    public static GameUICanvas Instance;

    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject gameUIPanel;   
    public GameObject pausePanel;    
    public GameObject OptionsPanel;
    public GameObject DialoguePanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        mainMenuPanel?.SetActive(false);
        gameUIPanel?.SetActive(false);
        pausePanel?.SetActive(false);
        OptionsPanel?.SetActive(false);
        DialoguePanel?.SetActive(false);
        
        if (scene.buildIndex == 0)
        {
            if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        }
        else
        {
        
            if (gameUIPanel != null) gameUIPanel.SetActive(true);
            //DialoguePanel?.SetActive(false);
        }
    }
}