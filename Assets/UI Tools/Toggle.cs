using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public List<GameObject> subjects;

    public void Execute()
	{
		foreach(GameObject subject in subjects)
		{
			subject.SetActive(!subject.activeInHierarchy);
		}
	}
}
