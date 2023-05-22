using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Interactions.InteractionsSO
{
    public class TalkInteraction : Interaction
    {
    
        [TextArea]
        public List<string> dialogues = new();

        public void OnAwake()
        {
            InteractionType = InteractionType.Talk;
        }

        public override void Interact()
        {
            base.Interact();
        }
    }
}
