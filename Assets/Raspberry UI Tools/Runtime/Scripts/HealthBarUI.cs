using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ColorPaletteUI;

[ExecuteAlways]
public class HealthBarUI : MonoBehaviour
{
    public UIState State;
    public float MaxHealth;
    public float CurHealth;
    public float Shield;
    [Range(0,1)]
    public float LowValue;
    public BarUI healthBar;
    public BarUI shieldBar;
	public Image background;
    private BarColor colorScheme;
    public float MaxValue
	{
        get
		{
			float combinedValue = CurHealth + Shield;
            return combinedValue > MaxHealth ? combinedValue : MaxHealth;
		}
	}

    void OnValidate()
    {
		if (UIManager.instance != null)
		{
			UIManager.instance.Unsubscribe(this);
		}

		if (UIManager.instance != null)
		{
			UIManager.instance.Subscribe(this);
		}
		healthBar.LowValue = LowValue;
		shieldBar.LowValue = LowValue;
        healthBar.Execute(MaxValue, CurHealth);
        shieldBar.Execute(MaxValue, Shield);
		UpdateColor();
    }

	public void OnEnable()
	{
        if (UIManager.instance != null)
		{
			UIManager.instance = FindObjectOfType<UIManager>();
			
			if (UIManager.instance == null)
			{
				GameObject go = new GameObject("UI Manager");
				UIManager cubeManager = go.AddComponent<UIManager>();
				UIManager.instance = cubeManager;
			}
		}

		UIManager.instance.Subscribe(this);

	}

	public void OnDisable()
	{
        if (UIManager.instance != null)
		{
			UIManager.instance.Unsubscribe(this);
		}

	}

	public void SetColor(BarColor barColor)
	{
		colorScheme = barColor;
		if (colorScheme == null || background == null) return;
		background.color = colorScheme.BackgroundPrimary;
		UpdateColor();
	}

	private void UpdateColor()
	{
		if (healthBar.Low)
		{
			healthBar.barImage.color = colorScheme.HealthSecondary;
		}
		else
		{
			healthBar.barImage.color = colorScheme.HealthPrimary;
		}

		if (shieldBar.Low)
		{
			shieldBar.barImage.color = colorScheme.ShieldSecondary;
		}
		else
		{
			shieldBar.barImage.color = colorScheme.ShieldPrimary;
		}
	}

	public void Execute(float shieldValue, float healthValue)
	{
        CurHealth = healthValue;
        Shield = shieldValue;
        healthBar.Execute(MaxValue, CurHealth);
        shieldBar.Execute(MaxValue, Shield);
    }
}
