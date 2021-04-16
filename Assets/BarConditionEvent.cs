using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarConditionEvent : MonoBehaviour
{
	public PercentCondition condition;
	public BarComponent barComponent;
	public void Execute()
	{
		if (condition.HasMetCondition(barComponent.percentValue))
		{
			Debug.Log("IT MET THE CONDITION");
		}
	}
}
