using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarComponent : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public float percentValue
	{ 
        get
		{
            return (slider.value / slider.maxValue) * 100;
		}
    }

    void Awake()
    {
        slider ??= GetComponent<Slider>();
    }

    public void SetValue(float maxValue, float currentValue, float minValue = 0)
	{
        slider.maxValue = maxValue;
        slider.minValue = minValue;
        SetCurrentValue(currentValue);
    }

    public void IncreaseValue(float value)
	{
        slider.value += value;
	}

    public void DecreaseValue(float value)
	{
        slider.value -= value;
	}

    public void SetCurrentValue(float currentValue)
	{
        if(slider.maxValue < currentValue)
		{
            currentValue = slider.maxValue;
		}
        else if( slider.minValue > currentValue)
		{
            currentValue = slider.minValue;
		}

        slider.value = currentValue;
	}
}
