using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.TryGetComponent<IInteractable>(out var interactable))
        {
            interactable.Interact();
        }
    }
}
