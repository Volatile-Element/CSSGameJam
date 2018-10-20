﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSingleton : Singleton<AnimalSingleton>
{
    public UnityEventFor<float> OnAnimalPercentageChange = new UnityEventFor<float>();

    public float AnimalPercentage { get; set; }
    
    public void Increase()
    {
        AnimalPercentage += 10;

        if (AnimalPercentage > 100)
        {
            //TODO: Fire an event that we have enough meats!
        }

        OnAnimalPercentageChange.Invoke(AnimalPercentage);
    }
}