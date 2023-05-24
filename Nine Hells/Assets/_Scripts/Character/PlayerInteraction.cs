using _Scripts.Interactions;
using UnityEngine;

namespace _Scripts.Character
{
    public class PlayerInteraction : MonoBehaviour
    {

        private InteractionObject _focusedObj;
        private bool _hasInteract = false;
        
        void Update()
        {
            InputInteract(_focusedObj);
        }

        private void InputInteract(InteractionObject interactable)
        {
            if(interactable == null) return;
            if(_focusedObj == null) return;

            if (_focusedObj == interactable && _hasInteract) return;
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact();
                _hasInteract = true;

                if (interactable.Interaction.InteractionType == InteractionType.Talk)
                {
                    PlayerController.CanMove = false;
                }
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
            _focusedObj = null;
            _hasInteract = false;
            interactable.Reset();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.TryGetComponent<InteractionObject>(out var interactable)) return;
            _focusedObj = null;
            _hasInteract = false;
            interactable.Reset();
        }
    }
}
