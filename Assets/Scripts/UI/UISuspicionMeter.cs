using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISuspicionMeter : MonoBehaviour
{
    private void Start()
    {
        GetComponentInParent<Customer>().OnSuspicionChange.AddListener((float percentage) =>
        {
            if (percentage <= 0)
            {
                UITool.Get<Slider>(transform, "Slider").gameObject.SetActive(false);
            }
            else
            {
                UITool.Get<Slider>(transform, "Slider").gameObject.SetActive(true);
            }

            UITool.Get<Slider>(transform, "Slider").value = percentage / 100;
        });
    }
}