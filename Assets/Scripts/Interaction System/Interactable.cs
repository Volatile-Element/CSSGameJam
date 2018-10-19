using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    public string _InteractionText;
    public string InteractionText { get { return _InteractionText; } set { _InteractionText = value; } }

    IEnumerable<IOnInteraction> onInteractions;

    private void Awake()
    {
        onInteractions = GetComponents<IOnInteraction>();
    }

    public void Interact()
    {
        foreach (var onInteraction in onInteractions)
        {
            onInteraction.OnInteraction(this);
        }
    }
}