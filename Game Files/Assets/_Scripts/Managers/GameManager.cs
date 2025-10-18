using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        
    }
    void Start()
    {
        pauseMusic = GameObject.FindGameObjectWithTag("UIAudio").GetComponent<AudioSource>();
        
        pauseMusic.Pause();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenu.activeSelf)
            {
                CloseOptions();
            }
            else
            {
                TogglePause();
            }
            //TogglePause();
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
        TogglePause();
    }
    
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.ResumeMusic();
        }
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
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
        
    }
    
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game button pressed.");

        
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
                        // If running in a build, close the application
                        Application.Quit();
        #endif
    }



}
