using System.Collections;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioSource audioSourceLight;
    public AudioSource audioSourceDark;
    public static BackgroundMusicManager Instance;

    private bool isLightMode = true;

    private void Awake()
    {
        // --- Singleton pattern (unchanged) ---
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Start the warm-up coroutine to preload both audio clips
        StartCoroutine(PreloadAudioSources());
    }

    private IEnumerator PreloadAudioSources()
    {
        // Preload both clips so Unity decodes them early, avoiding runtime freeze
        audioSourceLight.Play();
        yield return new WaitForSeconds(0.05f);
        audioSourceLight.Pause();

        audioSourceDark.Play();
        yield return new WaitForSeconds(0.05f);
        audioSourceDark.Pause();

        // Start in light mode
        isLightMode = true;
        audioSourceLight.Play();
        audioSourceDark.Stop();
    }

    public void SwitchMusic()
    {
        float currentTime;

        if (isLightMode)
        {
            currentTime = audioSourceLight.time;
            audioSourceLight.Pause();

            // Safely clamp to avoid overflow past the clip length
            audioSourceDark.time = Mathf.Min(currentTime, audioSourceDark.clip.length - 0.01f);
            audioSourceDark.Play();
        }
        else
        {
            currentTime = audioSourceDark.time;
            audioSourceDark.Pause();

            audioSourceLight.time = Mathf.Min(currentTime, audioSourceLight.clip.length - 0.01f);
            audioSourceLight.Play();
        }

        isLightMode = !isLightMode;
    }
}