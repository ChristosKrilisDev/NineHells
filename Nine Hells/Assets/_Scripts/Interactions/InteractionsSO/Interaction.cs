using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Interactions.InteractionsSO
{
    public class Interaction: MonoBehaviour
    {
        public bool CanInteract = true;
        public InteractionType InteractionType;
        public UnityEvent exitEvent;

        //public virtual void Interact()
        //{
        //    Debug.Log("TOM");
        //}

        public virtual void ResetData()
        {
            CanInteract = true;
        }

        public virtual void Run()
        {
            Debug.Log("TOM");
        }
    }
}
