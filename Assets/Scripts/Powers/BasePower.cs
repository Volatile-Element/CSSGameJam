using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePower : MonoBehaviour
{
    public float ChargePercentage;

    public abstract void UsePower();

    public bool CanUse()
    {
        return ChargePercentage > 0;
    }
}