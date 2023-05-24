using System;
using Cinemachine;
using DG.Tweening;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Interactions.InteractionsSO
{
    public class MyEvent : UnityEvent<Transform[]> { }

    public class UseInteraction : Interaction
    {

        public MyEvent unityEvent;

        [SerializeField] private Transform _initialPos;
        [SerializeField] private Transform _placementTransform;
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

            if(unityEvent != null) unityEvent.Invoke(new Transform[] { transform, _initialPos, _placementTransform });
        }

        public override void ResetData()
        {
            base.ResetData();

            transform.localPosition = _initialPos.transform.localPosition;
            transform.localRotation = _initialPos.transform.localRotation;

        }

    }
}
