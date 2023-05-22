using _Scripts.Interactions.InteractionsSO;
using UnityEngine;
namespace _Scripts.Interactions
{
    public class InteractionObject : MonoBehaviour
    {
        [SerializeField] private Interaction _interaction;

    
        public InteractionCanvas InteractionCanvas;

        public void Start()
        {
            InteractionCanvas.gameObject.SetActive(false);
        }

        public void DisplayUI()
        {
            if(!_interaction.CanInteract) return;
        
            InteractionCanvas.gameObject.SetActive(true);
            InteractionCanvas.DisplayInteractionText(_interaction.InteractionType.ToString().ToUpper());
            // Debug.Log($"IInteraction: {_interaction.interactionType.ToString()}");

        }

        public void Interact()
        {
            if(!_interaction.CanInteract) return;
            InteractionCanvas.gameObject.SetActive(false);
            _interaction.Run();
        }

        public void Reset()
        {
            InteractionCanvas.gameObject.SetActive(false);
        }
    
    }
}
