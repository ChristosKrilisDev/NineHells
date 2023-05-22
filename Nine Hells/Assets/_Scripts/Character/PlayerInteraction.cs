using _Scripts.Interactions;
using UnityEngine;

namespace _Scripts.Character
{
    public class PlayerInteraction : MonoBehaviour
    {

        private InteractionObject _focusedObj;

        void Update()
        {
            InputInteract(_focusedObj);
        }

        private void InputInteract(InteractionObject interactable)
        {
            if(interactable == null) return;
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact();
            }
        }

        private void OnEnter(Collision other)
        {
            if (!other.gameObject.TryGetComponent<InteractionObject>(out var interactable)) return;
            interactable.DisplayUI();
            _focusedObj = interactable;
        }
        
        private void OnEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent<InteractionObject>(out var interactable)) return;
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
            if (!other.gameObject.TryGetComponent<InteractionObject>(out var interactable)) return;
            interactable.Reset();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.TryGetComponent<InteractionObject>(out var interactable)) return;
            interactable.Reset();
        }
    }
}
