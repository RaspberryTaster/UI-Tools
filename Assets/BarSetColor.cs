using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarSetColor : MonoBehaviour
{
	private BarComponent barComponent;

	public PercentCondition condition;
	public Image fill;
	public Color conditionMetColor;

	private void Awake()
	{
		barComponent = GetComponent<BarComponent>();
	}
	public void Execute()
	{
		if (condition.HasMetCondition(barComponent.percentValue))
		{
			fill.color = conditionMetColor;
		}
	}
}
