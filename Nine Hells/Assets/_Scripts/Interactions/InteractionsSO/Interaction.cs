using UnityEngine;
namespace _Scripts.Interactions.InteractionsSO
{
    public class Interaction: MonoBehaviour
    {
        public bool CanInteract = true;
        public InteractionType InteractionType;

        public virtual void Interact()
        {

        }

        public virtual void ResetData()
        {
            CanInteract = true;
        }

        public virtual void Run()
        {
            
        }
    }
}
