using Cinemachine;
using DG.Tweening;
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
            gameObject.tag = _tagKey.ToString();
            GetComponent<BoxCollider>().enabled = false;
            transform.DOLocalMove(_placementTransform.localPosition, 0.4f)
                     .OnComplete(() =>
                        {
                            GetComponent<BoxCollider>().enabled = true;
                        }
                      );
            transform.DOLocalRotate(_placementTransform.transform.eulerAngles, 0.4f);
        }

        public override void ResetData()
        {
            base.ResetData();

            transform.localPosition = _initialPos.transform.localPosition;
            transform.localRotation = _initialPos.transform.localRotation;

        }

    }
}
