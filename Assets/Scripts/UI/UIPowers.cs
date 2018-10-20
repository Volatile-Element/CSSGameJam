using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPowers : MonoBehaviour
{
	void Start ()
    {
        var template = transform.Find("Power Template");
        var powersContainer = transform.Find("Powers");

        foreach (var power in PowersSingleton.Instance.Powers)
        {
            var panel = Instantiate(template);
            panel.transform.SetParent(powersContainer);

            panel.gameObject.SetActive(true);

            UITool.Get<Text>(panel.transform, "txtPowerName").text = power.Name;
            UITool.Get<Slider>(panel.transform, "Slider").value = power.ChargePercentage / 100;

            if (power.CanUse())
            {
                panel.transform.Find("Slider/Fill Area/Fill").GetComponent<Image>().color = Color.green;
            }
            else
            {
                panel.transform.Find("Slider/Fill Area/Fill").GetComponent<Image>().color = Color.red;
            }

            power.OnChargeChange.AddListener((float charge) =>
            {
                if (power.CanUse())
                {
                    panel.transform.Find("Slider/Fill Area/Fill").GetComponent<Image>().color = Color.green;
                }
                else
                {
                    panel.transform.Find("Slider/Fill Area/Fill").GetComponent<Image>().color = Color.red;
                }

                UITool.Get<Slider>(panel.transform, "Slider").value = charge / 100;
            });
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}