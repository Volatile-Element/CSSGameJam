using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInteractionRestorePowers : MonoBehaviour, IOnInteraction
{
    public void OnInteraction(Interactable interactable)
    {
        PowersSingleton.Instance.Recharge();
    }
}