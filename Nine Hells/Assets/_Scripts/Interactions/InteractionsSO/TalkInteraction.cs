using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _Scripts.Interactions.InteractionsSO
{
    public class TalkInteraction : Interaction
    {

        public UnityEvent unityEvent;

        [TextArea]
        public List<string> dialogues = new();

        public void OnAwake()
        {
            InteractionType = InteractionType.Talk;
        }

        public override void Interact()
        {
            base.Interact();
            
            if(unityEvent!=null)unityEvent.Invoke();
        }

        public override void Run()
        {
            base.Run();

            if (unityEvent != null) unityEvent.Invoke();
        }
    }
}
