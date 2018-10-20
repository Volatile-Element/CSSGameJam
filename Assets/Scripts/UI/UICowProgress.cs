using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICowProgress : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        AnimalSingleton.Instance.OnAnimalPercentageChange.AddListener((float percentage) =>
        {
            UITool.Get<Slider>(transform, "Slider").value = percentage / 100;
        });
    }
}