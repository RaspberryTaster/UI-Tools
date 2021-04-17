using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{
    private RectTransform rect;
    public enum TargetType
	{ 
        TRANSFORM, POINTER
    }
    public TargetType targetType;
    public Transform objectToFollow;
    // Start is called before the first frame update
    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

	private void Update()
	{
        Reposition();
    }

    Vector2 newPosition;
    Vector2 pivot;
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

        newPosition = ViewportPosition;
        pivot.x = newPosition.x / Screen.width;
        pivot.y = newPosition.y / Screen.height;
        rect.pivot = pivot;
        transform.position = newPosition;
    }
}
