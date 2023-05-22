using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Interactions.InteractionsSO
{
    [CreateAssetMenu(fileName = "TalkInteraction", menuName = "Interactions/Talk", order = 1)]
    public class TalkInteraction : Interaction
    {
    
        [TextArea]
        public List<string> dialogues = new();

        public void OnAwake()
        {
            interactionType = InteractionType.Talk;
        }

        public override void Interact()
        {
            base.Interact();
        }
    }
}