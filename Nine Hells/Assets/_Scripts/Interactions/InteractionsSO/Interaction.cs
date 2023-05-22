using System;
using UnityEngine;
namespace _Scripts.Interactions.InteractionsSO
{
    public class Interaction: ScriptableObject
    {
        public bool CanInteract = true;
    
        public InteractionType interactionType;

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