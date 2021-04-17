using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
	public TextMeshProUGUI headerField;
	public TextMeshProUGUI contentField;
	public LayoutElement layoutElement;
	public int characterWrapLimit;
	public RectTransform rectTransform;
	public Canvas canvas;
	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
	}
	public void SetText(string content, string header  = "")
	{
		if(string.IsNullOrEmpty(header))
		{
			headerField.gameObject.SetActive(false);

		}
		else
		{

			headerField.gameObject.SetActive(true);
			headerField.text = header;
		}

		contentField.text = content;

		AdjustSize();
	}

	Vector3 newPosition;
	Vector2 pivot;
	private void Update()
	{
		if (Application.isEditor)
		{
			AdjustSize();
		}

		//SetPosition();
	}

	public void SetPosition()
	{
		newPosition = Input.mousePosition;
		pivot.x = newPosition.x / Screen.width;
		pivot.y = newPosition.y / Screen.height;
		rectTransform.pivot = pivot;
		transform.position = newPosition;
	}

	private void AdjustSize()
	{
		int headerLength = headerField.text.Length;
		int contentLength = contentField.text.Length;
		layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
	}
}
