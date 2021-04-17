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
	public Color conditionNotMetColor;

	private void Awake()
	{
		barComponent = GetComponent<BarComponent>();
	}
	public void Execute()
	{
		if (condition.HasMetCondition(barComponent.percentValue))
		{
			if(fill.color != conditionMetColor)
			{
				fill.color = conditionMetColor;
			}
		}
		else
		{
			if (fill.color != conditionNotMetColor)
			{
				fill.color = conditionNotMetColor;
			}
		}
	}
}
