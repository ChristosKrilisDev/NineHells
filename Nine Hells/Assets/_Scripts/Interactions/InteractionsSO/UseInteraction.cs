using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Interactions.InteractionsSO
{
    public class MyEvent : UnityEvent<Transform[]> { }

    public class UseInteraction : Interaction
    {

        public UnityEvent<List<Transform>> UnityEvent;

        [SerializeField] private List<Transform> _transforms;
        // [SerializeField] private Transform _initialPos;
        // [SerializeField] private Transform _placementTransform;
        [TagField, SerializeField] private string _tagKey;

        private void Start()
        {
            // gameObject.transform.localPosition = _initialPos.transform.localPosition;
        }

        public override void Run()
        {
            base.ResetData();
            CanInteract = false;
            gameObject.tag = _tagKey.ToString();
            //GetComponent<BoxCollider>().enabled = false;
            //transform.DOLocalMove(_placementTransform.localPosition, 0.4f).OnComplete(() =>
            //{
            //    GetComponent<BoxCollider>().enabled = true;
            //});
            //transform.DOLocalRotate(_placementTransform.transform.eulerAngles, 0.4f);

            if(UnityEvent != null) UnityEvent.Invoke(_transforms);
        }

        public override void ResetData()
        {
            base.ResetData();

            transform.localPosition = _transforms[0].transform.localPosition;
            transform.localRotation = _transforms[0].transform.localRotation;

        }

    }
}
