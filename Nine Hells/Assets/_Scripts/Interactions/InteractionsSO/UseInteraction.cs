using UnityEngine;

namespace _Scripts.Interactions.InteractionsSO
{
    [CreateAssetMenu(fileName = "UseInteraction", menuName = "Interactions/Use", order = 1)]
    public class UseInteraction : Interaction
    {
        public void OnAwake()
        {
            interactionType = InteractionType.Use;
        }

    }
}
