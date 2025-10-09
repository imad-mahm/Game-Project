using UnityEngine;

public class themeBackground : MonoBehaviour
{
    public Sprite lightSprite;
    public Sprite darkSprite;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ThemeManager.OnThemeChanged += UpdateBackground;
        UpdateBackground(ThemeManager.Instance.isLightMode);
    }

    void UpdateBackground(bool isLight)
    {
        sr.sprite = isLight ? lightSprite : darkSprite;
    }
}