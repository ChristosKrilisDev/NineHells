using _Scripts;
using _Scripts.Interactions;
using _Scripts.Interactions.InteractionsSO;
using UnityEngine;

public class InteractionObject : MonoBehaviour, IInteractable
{
    [SerializeField] private Interaction _interaction;

    
    public InteractionCanvas InteractionCanvas;

    public void Start()
    {
        InteractionCanvas.gameObject.SetActive(false);
    }

    public void Interact()
    {
        if(!_interaction.CanInteract) return;
        
        InteractionCanvas.gameObject.SetActive(true);
        InteractionCanvas.DisplayInteractionText(_interaction.interactionType.ToString().ToUpper());
        // Debug.Log($"IInteraction: {_interaction.interactionType.ToString()}");

    }

    public void Reset()
    {
        InteractionCanvas.gameObject.SetActive(false);
    }
    
}
