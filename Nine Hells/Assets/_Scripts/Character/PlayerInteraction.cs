using _Scripts.Interactions;
using UnityEngine;

namespace _Scripts.Character
{
    public class PlayerInteraction : MonoBehaviour
    {

        private IInteractable _focusedObj;

        void Update()
        {
            InputInteract(_focusedObj);
        }

        private void InputInteract(IInteractable interactable)
        {
            if(interactable == null) return;
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                ((InteractionObject)interactable).Interact();
            }
        }

        private void OnEnter(Collision other)
        {
            if (!other.gameObject.TryGetComponent<IInteractable>(out var interactable)) return;
            interactable.DisplayUI();
            _focusedObj = interactable;
        }
        
        private void OnEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent<IInteractable>(out var interactable)) return;
            interactable.DisplayUI();
            _focusedObj = interactable;
        }
        
        
        
        private void OnCollisionEnter(Collision other)
        {

            OnEnter(other);
        }

        private void OnTriggerEnter(Collider other)
        {
            OnEnter(other);
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
