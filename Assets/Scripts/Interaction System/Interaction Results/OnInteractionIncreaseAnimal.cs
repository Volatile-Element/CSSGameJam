using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInteractionIncreaseAnimal : MonoBehaviour, IOnInteraction
{
    public void OnInteraction(Interactable interactable)
    {
        AnimalSingleton.Instance.Increase();
    }
}