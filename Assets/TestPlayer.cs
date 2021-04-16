using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public BarComponent barComponent;
    // Start is called before the first frame update
    void Start()
    {
        barComponent.SetValue(maxHealth, currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
		{
            barComponent.DecreaseValue(2);
		}
    }
}
