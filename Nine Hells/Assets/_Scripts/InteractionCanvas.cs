using System;
using DG.Tweening;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace _Scripts
{
    public class InteractionCanvas : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [CanBeNull] private Camera _camera;
        
        private void OnEnable()
        {
            _camera = Camera.main;
            Vector3 pos = Vector3.up * 2;
            transform.localPosition = pos;
            AnimateUp();
        }

        private void OnDisable()
        {
            transform.DOKill();
        }

        private void AnimateUp()
        {
            transform.DOKill();
            transform.DOMoveY(transform.position.y + 0.25f,0.5f).OnComplete(()=> AnimateDown());
        }

        private void AnimateDown()
        {
            transform.DOKill();
            transform.DOMoveY(transform.position.y - 0.25f,0.5f).OnComplete(()=> AnimateUp());
        }

        private void Update()
        {
            if (_camera == null) return;
            
            var lookAtPosition = _camera.transform.position;
            lookAtPosition.y = transform.position.y;
            transform.LookAt(2 * transform.position - lookAtPosition);
        }


        public void DisplayInteractionText(string interaction)
        {
            _textMeshPro.text = interaction;
        }
        
    }
}
