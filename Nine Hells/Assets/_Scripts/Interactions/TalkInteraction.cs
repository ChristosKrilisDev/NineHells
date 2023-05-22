using _Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
