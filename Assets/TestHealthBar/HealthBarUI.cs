using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public float MaxHealth;
    public float CurHealth;
    public float Shield;

    public Image HealthFill;
    public Image ShieldFill;

    public float MaxValue
	{
        get
		{
			float combinedValue = CurHealth + Shield;
            return combinedValue > MaxHealth ? combinedValue : MaxHealth;
		}
	}
    public float HealthNormalized
	{
        get
		{
			float value = CurHealth == 0 || MaxValue == 0 ? 0 : CurHealth / MaxValue;
            return Mathf.Clamp01(value);

        }
	}
    public float ShieldNormalized
	{
        get
		{
			float value = Shield == 0 || MaxValue == 0 ? 0 : Shield / MaxValue;
			return Mathf.Clamp01(value);

        }
	}
    void OnValidate()
    {
        HealthFill.fillAmount = HealthNormalized;
        ShieldFill.fillAmount = Mathf.Clamp01(HealthNormalized + ShieldNormalized);
    }
}
