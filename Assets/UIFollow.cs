using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{
    public RectTransform targetCanvas;
    private RectTransform rect;
    public enum TargetType
	{ 
        TRANSFORM, POINTER
    }
    public TargetType targetType;
    public Transform objectToFollow;
    public Vector2 Offset;
    // Start is called before the first frame update
    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }


    private void Reposition()
    {
        Vector2 ViewportPosition = Vector2.zero;

        if (targetType == TargetType.TRANSFORM)
		{
            ViewportPosition = Camera.main.WorldToViewportPoint(objectToFollow.position);
        }
        else if( targetType == TargetType.POINTER)
		{
            ViewportPosition = Input.mousePosition;
        }

        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * targetCanvas.sizeDelta.x) - ((targetCanvas.sizeDelta.x * 0.5f)) + Offset.x),
        ((ViewportPosition.y * targetCanvas.sizeDelta.y) - (targetCanvas.sizeDelta.y * 0.5f)) + Offset.y);
        rect.anchoredPosition = WorldObject_ScreenPosition;
    }
}
