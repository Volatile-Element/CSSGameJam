using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePower : MonoBehaviour
{
    public UnityEventFor<float> OnChargeChange = new UnityEventFor<float>();

    public abstract string Name { get; set; }
    public abstract float UseCost { get; set; }
    public abstract float RechargeAmount { get; set; }

    public float ChargePercentage;

    public abstract void UsePower();

    public bool CanUse()
    {
        return ChargePercentage >= UseCost;
    }

    public void Recharge()
    {
        BaseChargeChange(RechargeAmount);
    }

    public void UseCharge()
    {
        BaseChargeChange(-UseCost);
    }

    private void BaseChargeChange(float amount)
    {
        ChargePercentage += amount;

        if (amount < 0)
        {
            ChargePercentage = 0;
        }

        if (amount > 100)
        {
            ChargePercentage = 100;
        }

        OnChargeChange.Invoke(ChargePercentage);
    }
}