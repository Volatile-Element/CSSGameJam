using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInteractionNotifyCustomer : MonoBehaviour, IOnInteraction
{
    public Customer OwningCustomer;

    public void OnInteraction(Interactable interactable)
    {
        if (OwningCustomer == null)
        {
            Debug.LogError("A food item does not have an owning customer set.");

            return;
        }

        OwningCustomer.FoodItemTaken();
    }

    public void SetOwningCustomer(Customer owningCustomer)
    {
        OwningCustomer = owningCustomer;
    }
}