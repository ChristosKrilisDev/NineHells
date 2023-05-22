using UnityEngine;

namespace _Scripts.Interactions.InteractionsSO
{
    [CreateAssetMenu(fileName = "UseInteraction", menuName = "Interactions/Use", order = 1)]
    public class UseInteraction : Interaction
    {

        [SerializeField] private GameObject _moveObject;
        [SerializeField] private Vector3 _initialPos;
        [SerializeField] private Vector3 _placementTransform;
        
        public void OnAwake()
        {
            interactionType = InteractionType.Use;
        }

        public override void Run()
        {
            base.ResetData();
            CanInteract = false;
            // _moveObject.transform.localPosition = _placementTransform;
        }

        public override void ResetData()
        {
            base.ResetData();

            _moveObject.transform.localPosition = _initialPos;
        }

    }
}
