using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raspberry.TooltipUI
{
	public class TooltipSystem : MonoBehaviour
	{
		public Tooltip tooltip;
		public FadeTween fadeTween;
		public void Show(string content, string header = "")
		{
			tooltip.SetText(content, header);
			tooltip.SetPosition();
			tooltip.gameObject.SetActive(true);
			fadeTween.FadeIn();
		}

		public void Hide()
		{
			fadeTween.FadeOut();
		}
	}
}

