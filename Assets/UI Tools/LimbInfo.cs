using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LimbInfo : MonoBehaviour
{
	public string LimbName;
	public TextMeshProUGUI LimbNameUI;
	public int Armor;
	public GameObject ArmorPointUIHolder;
	public TextMeshProUGUI ArmorPointUI;

	private void OnValidate()
	{
		SetLimbNameUI(LimbName);
		SetArmorUI(Armor);
	}

	public void SetLimbNameUI(string name)
	{
		LimbNameUI.text = name;
	}
	public void SetArmorUI(int Armor)
	{
		if(Armor == 0)
		{
			ArmorPointUIHolder.SetActive(false);
		}
		else
		{
			ArmorPointUIHolder.SetActive(true);
			ArmorPointUI.text = Armor.ToString();
		}

	}
}
