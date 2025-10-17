using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isPaused = false;
    
    [Header("UI References")]
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    
    [Header("Audio")]
    private AudioSource pauseMusic;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        pauseMusic = GameObject.FindGameObjectWithTag("UIAudio").GetComponent<AudioSource>();
    }
    void Start()
    {
        
        pauseMusic.Play();
        pauseMusic.Pause();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;  
            pauseMenu.SetActive(true);
            if (BackgroundMusicManager.Instance != null)
            {
                BackgroundMusicManager.Instance.PauseMusic();
            }
            pauseMusic.Pause();
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            if (BackgroundMusicManager.Instance != null)
            {
                BackgroundMusicManager.Instance.ResumeMusic();
            }
            pauseMusic.UnPause();
        
        }
    }

    public bool IsPaused()
    {
        return isPaused;
    }
    
    public void ResumeGame()
    {
        Debug.Log("Resuming game");
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenu.SetActive(false);
    }
    
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OpenOptions()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
    

}
