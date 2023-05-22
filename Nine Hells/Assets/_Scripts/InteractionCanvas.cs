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
