using _Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour, IInteractable
{
    [SerializeField] private Interaction interaction;

    public void Interact()
    {
        Debug.Log($"IInteraction: {interaction.interactionType.ToString()}");

    }
}
