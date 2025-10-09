using UnityEngine;

public class themePlatformParticles : MonoBehaviour
{
    public bool isLightPlatform;
    private Collider2D col;
    private ParticleSystem ps;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        ps = GetComponentInChildren<ParticleSystem>();
    }

    private void OnEnable()
    {
        ThemeManager.OnThemeChanged += UpdatePlatform;
    }

    private void OnDisable()
    {
        ThemeManager.OnThemeChanged -= UpdatePlatform;
    }

    void UpdatePlatform(bool isLight)
    {
        bool active = (isLight == isLightPlatform);

        col.enabled = active;

        if (ps != null)
        {
            if (!active) ps.Play();  // show particles when inactive
            else ps.Stop();          // stop when solid
        }
    }
}