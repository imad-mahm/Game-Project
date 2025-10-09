
using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    public static ThemeManager Instance;
    public bool isLightMode = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ToggleTheme()
    {
        isLightMode = !isLightMode;

        // Call an event or function to update platforms and visuals
        OnThemeChanged?.Invoke(isLightMode);
    }

    public delegate void ThemeChangeAction(bool isLight);
    public static event ThemeChangeAction OnThemeChanged;
}
