using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractAllPower : BasePower
{
    public override string Name { get; set; } = "Distract All";
    public override float UseCost { get; set; } = 100;
    public override float RechargeAmount { get; set; } = 5;
    
    public override void UsePower()
    {
        foreach (var customer in FindObjectsOfType<Customer>())
        {
            customer.LookAwayFromPlate();
        }

        UseCharge();
    }
}