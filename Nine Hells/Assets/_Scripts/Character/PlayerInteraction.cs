using _Scripts.Interactions;
using UnityEngine;

namespace _Scripts.Character
{
    public class PlayerInteraction : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {

            if (!collision.gameObject.TryGetComponent<IInteractable>(out var interactable)) return;
            interactable.Interact();
        }
        
        private void OnTriggerEnter(Collider other)
        {

            if (!other.gameObject.TryGetComponent<IInteractable>(out var interactable)) return;
            interactable.Interact();
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
