using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
	public ColorPaletteUI ColorPaletteUI;
	private void OnEnable()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	[SerializeField] private List<HealthBarUI> healthBars = new List<HealthBarUI>();
	public BarColor Set(UIState state)
	{
		if (state == UIState.friendly)
		{
			return ColorPaletteUI.friendlyBar;
		}
		else
		{
			return ColorPaletteUI.enemyBar;
		}
	}

	public void Subscribe(HealthBarUI healthBarUI)
	{
		if (healthBars.Contains(healthBarUI)) return;
		healthBars.Add(healthBarUI);
		if (ColorPaletteUI == null) return;
		healthBarUI.SetColor(Set(healthBarUI.State));

	}
	public void Unsubscribe(HealthBarUI healthBarUI)
	{
		if (!healthBars.Contains(healthBarUI)) return;
		healthBars.Remove(healthBarUI);
	}
	private void OnValidate()
	{
		UpdateSubscribers();
	}

	public void UpdateSubscribers()
	{
		foreach (HealthBarUI barUI in healthBars)
		{
			if (ColorPaletteUI == null) return;
			barUI.SetColor(Set(barUI.State));
		}
	}
}
