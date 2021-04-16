using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Condition/Percent Condition")]
public class PercentCondition : Condition
{
    public enum Condition
	{
        GREATER_THAN, GREATER_THAN_OR_EQUAL_TO, LESSER_THAN, LESSER_THAN_OR_EQUAL_TO, EQUAL_TO, NOT_EQUAL_TO
	}

    public Condition condition;
	[Range(0.0f, 100.0f)]
    public float value;

    public bool HasMetCondition(float percentValue)
	{
        bool value = false;

        if(condition == Condition.GREATER_THAN)
		{
			 value = this.value < percentValue;
		}
		else if (condition == Condition.GREATER_THAN_OR_EQUAL_TO)
		{
			value = this.value <= percentValue;
		}
		else if (condition == Condition.LESSER_THAN)
		{
			value = this.value > percentValue;
		}
		else if (condition == Condition.LESSER_THAN_OR_EQUAL_TO)
		{
			value = this.value >= percentValue;
		}
		else if(condition == Condition.EQUAL_TO)
		{
			value = this.value == percentValue;
		}
		else if(condition == Condition.NOT_EQUAL_TO)
		{
			value = this.value != percentValue;
		}

		return value;
	}
}
