using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _Scripts.Interactions.InteractionsSO
{
    public class TalkInteraction : Interaction
    {

        public UnityEvent unityEvent;
        public UnityEvent finishEvent;

        [TextArea]
        [SerializeField] private string charName = "";
        [SerializeField] private List<string> dialogues = new();

        public void OnAwake()
        {
            InteractionType = InteractionType.Talk;
        }

        public override void Run()
        {
            base.Run();

            if (unityEvent != null) unityEvent.Invoke();
            Debug.Log("Typing");
            TextRendererManager.instance.ShowNewDialogue(dialogues, charName, this);
        }

        public void Finish()
        {
            if(finishEvent!=null)finishEvent.Invoke();
        }
    }
}
