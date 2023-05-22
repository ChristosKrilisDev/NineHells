using UnityEngine;

namespace _Scripts.Interactions.InteractionsSO
{
    [CreateAssetMenu(fileName = "MoveInteraction", menuName = "Interactions/Move", order = 1)]
    public class MoveInteraction : Interaction
    {
        public void OnAwake()
        {
            interactionType = InteractionType.Talk;
        }

    }
}
