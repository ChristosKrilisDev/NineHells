using DG.Tweening;
using UnityEngine;
namespace _Scripts
{
    public class Rocks : MonoBehaviour
    {
        [SerializeField] private GameObject _rocks1;
        [SerializeField] private GameObject _rocks2;

        private int _hitCount= -1;

        public void HitRocks()
        {
            _hitCount++;

            if (_hitCount <= 2)
            {
                _rocks1.transform.DOLocalMoveY(_rocks1.transform.localPosition.y -0.35f, 0.2f);
                _rocks2.transform.DOLocalMoveY(_rocks2.transform.localPosition.y -0.35f, 0.2f);
                // transform.DOLocalMoveY(-0.35f, 0.2f);

            }
            else
            {
                _rocks1.transform.DOLocalMoveY(_rocks1.transform.localPosition.y -3f, 0.2f);
                _rocks2.transform.DOLocalMoveY(_rocks2.transform.localPosition.y -3f, 0.2f);
                
                transform.DOMoveX(-0.01f, 0.3f).OnComplete(() =>
                {
                    transform.gameObject.GetComponent<BoxCollider>().enabled = false;
                });
            }
        }
    }
}
