using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersSingleton : Singleton<PowersSingleton>
{
    private void Start()
    {
        Recharge();
    }

    public void Recharge()
    {
        var powerController = FindObjectOfType<PowerController>();

        foreach (var power in powerController.Powers)
        {
            power.ChargePercentage += 10;
        }
    }
}