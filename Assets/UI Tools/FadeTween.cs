using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadeTween : MonoBehaviour
{
	public CanvasGroup canvasGroup;
	public float fadeInTime = 2f;
	public float fadeOutTime = 2f;
	public UnityEvent onFadeIn;
	public UnityEvent onFadeOut;
	public void FadeIn()
	{
		LeanTween.alphaCanvas(canvasGroup, 1, fadeInTime).setOnComplete(onFadeIn.Invoke);
	}


	public void FadeOut()
	{
		LeanTween.alphaCanvas(canvasGroup, 0, fadeOutTime).setOnComplete(onFadeOut.Invoke);
	}
}
