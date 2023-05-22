using _Scripts.Interactions;
using UnityEngine;

namespace _Scripts.Character
{
    public class PlayerInteraction : MonoBehaviour
    {

        private void InputInteract(IInteractable interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ((InteractionObject)interactable).Interact();
            }
        }
        
        private void OnCollisionEnter(Collision collision)
        {

            if (!collision.gameObject.TryGetComponent<IInteractable>(out var interactable)) return;
            interactable.DisplayUI();
            
            InputInteract(interactable);
        }
        
        private void OnTriggerEnter(Collider other)
        {

            if (!other.gameObject.TryGetComponent<IInteractable>(out var interactable)) return;
            interactable.DisplayUI();
            
            InputInteract(interactable);
        }

        private void OnCollisionExit(Collision other)
        {
            if (!other.gameObject.TryGetComponent<IInteractable>(out var interactable)) return;
            ((InteractionObject)interactable).Reset();
        }

        
        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.TryGetComponent<IInteractable>(out var interactable)) return;
            ((InteractionObject)interactable).Reset();
        }
    }
}
