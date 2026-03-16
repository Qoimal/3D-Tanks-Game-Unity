using UnityEngine;

public class SafeArea : MonoBehaviour
{
    void Start()
    {
        Rect safe = Screen.safeArea;

        RectTransform rect = GetComponent<RectTransform>();

        Vector2 min = safe.position;
        Vector2 max = safe.position + safe.size;

        min.x /= Screen.width;
        min.y /= Screen.height;
        max.x /= Screen.width;
        max.y /= Screen.height;

        rect.anchorMin = min;
        rect.anchorMax = max;
    }
}