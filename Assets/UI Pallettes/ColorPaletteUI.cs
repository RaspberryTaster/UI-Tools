using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIState
{
	friendly, enemy
}
[System.Serializable]
public class BarColor
{
	public Color HealthPrimary;
	public Color HealthSecondary;
	public Color ShieldPrimary;
	public Color ShieldSecondary;
	public Color BackgroundPrimary;
	public Color BackgroundSecondary;
}
[CreateAssetMenu]
public class ColorPaletteUI : ScriptableObject
{
	[TextArea]
	[SerializeField] private string Source;
	[TextArea(10,10)]
	[SerializeField] private string Description;
	public Color[] colorPalette;

	public BarColor friendlyBar;
	public BarColor enemyBar;

	private void OnValidate()
	{
		if (UIManager.instance == null) return;
		UIManager.instance.UpdateSubscribers();
	}
}
