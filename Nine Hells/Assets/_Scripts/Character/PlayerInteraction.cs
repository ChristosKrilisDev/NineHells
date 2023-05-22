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
<<<<<<< HEAD
            interactable.Interact();
=======
            interactable.OnInteract();
>>>>>>> ba4a540a25870412cc47c0427ddbe04d66ac2132
        }
    }
}
