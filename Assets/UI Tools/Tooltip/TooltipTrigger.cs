using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Raspberry.TooltipUI
{
	public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField] private TooltipSystem tooltipSystem;

		public string content;
		public string header;
		public float delayTime = 0.5f;
		public void OnPointerEnter(PointerEventData eventData)
		{
			Timing.RunCoroutine(Show());
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			Timing.KillCoroutines();
			tooltipSystem?.Hide();
		}

		public void OnMouseEnter()
		{
			Timing.RunCoroutine(Show());
		}
		public void OnMouseExit()
		{
			Timing.KillCoroutines();
			tooltipSystem?.Hide();
		}

		IEnumerator<float> Show()
		{
			yield return Timing.WaitForSeconds(delayTime);
			tooltipSystem?.Show(content, header);
		}

	}

}
