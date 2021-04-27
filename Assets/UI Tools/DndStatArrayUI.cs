using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DndStatArrayUI : MonoBehaviour
{
    public TextMeshProUGUI strengthUI;
    public TextMeshProUGUI dexterityUI;
    public TextMeshProUGUI constitutionUI;
    public TextMeshProUGUI intelligenceUI;
    public TextMeshProUGUI wisdomUI;
    public TextMeshProUGUI charismaUI;


    public void Set(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
	{
        strengthUI.text = strength.ToString();
        dexterityUI.text = dexterity.ToString();
        constitutionUI.text = constitution.ToString();
        intelligenceUI.text = intelligence.ToString();
        wisdomUI.text = wisdom.ToString();
        charismaUI.text = charisma.ToString();
	}
}
