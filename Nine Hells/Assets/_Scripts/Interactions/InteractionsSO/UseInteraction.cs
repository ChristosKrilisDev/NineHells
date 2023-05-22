using Cinemachine;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

namespace _Scripts.Interactions.InteractionsSO
{
    public class UseInteraction : Interaction
    {

        [SerializeField] private Transform _initialPos;
        [SerializeField] private Transform _placementTransform;
        [TagField, SerializeField] private string _tagKey;
        

        public override void Run()
        {
            base.ResetData();
            CanInteract = false;
            transform.localPosition = _placementTransform.transform.localPosition;
            transform.localRotation = _placementTransform.transform.localRotation;

            gameObject.tag = _tagKey.ToString();

            // if (_tagKey.ToString().ToLower() == "ladder")
            // {
            // }
        }

        public override void ResetData()
        {
            base.ResetData();

            transform.localPosition = _initialPos.transform.localPosition;
            transform.localRotation = _initialPos.transform.localRotation;

        }

    }
}
