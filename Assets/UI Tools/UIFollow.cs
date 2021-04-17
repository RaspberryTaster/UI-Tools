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
    public Canvas targetCanvas;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

	private void Update()
	{
        FollowCursor();
    }

	public bool StayWithinScreen;
	public float padding;
	private void FollowCursor()
	{
		Vector3 newPos = Vector3.zero;

		if (targetType == TargetType.TRANSFORM)
		{
			newPos = Camera.main.WorldToViewportPoint(objectToFollow.position);
		}
		else if (targetType == TargetType.POINTER)
		{
			newPos = Input.mousePosition;
		}

		newPos.z = 0f;

		if(StayWithinScreen)
		{
			newPos = AdjustWithinScreen(newPos);
		}

		rect.transform.position = newPos;
	}

	private Vector3 AdjustWithinScreen(Vector3 newPos)
	{
		float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + rect.rect.width * targetCanvas.scaleFactor / 2) - padding;
		if (rightEdgeToScreenEdgeDistance < 0)
		{
			newPos.x += rightEdgeToScreenEdgeDistance;
		}
		float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - rect.rect.width * targetCanvas.scaleFactor / 2) + padding;
		if (leftEdgeToScreenEdgeDistance > 0)
		{
			newPos.x += leftEdgeToScreenEdgeDistance;
		}
		float topEdgeToScreenEdgeDistance = Screen.height - (newPos.y + rect.rect.height * targetCanvas.scaleFactor / 2) - padding;
		if (topEdgeToScreenEdgeDistance < 0)
		{
			newPos.y += topEdgeToScreenEdgeDistance;
		}
		float bottomEdgeToScreenEdgeDistance = 0 - (newPos.y - rect.rect.height * targetCanvas.scaleFactor / 2) + padding;
		if (bottomEdgeToScreenEdgeDistance > 0)
		{
			newPos.y += bottomEdgeToScreenEdgeDistance;
		}

		return newPos;
	}
}
