using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
namespace _Scripts.Character
{
    public class MoralityBarGUI : MonoBehaviour
    {

        [SerializeField] private List<Transform> _points;
        [SerializeField] private GameObject _indicator;
        private int _currentScore;


        public void Init()
        {
            _currentScore = _points.Count / 2;
            _indicator.transform.SetParent(_points[_currentScore].transform);
            Vector3 newPos = new Vector3(0, 25.89999f, -0.5f);
            _indicator.transform.DOLocalMove(newPos, 0f);
        }
        
        public void UpdateMoralityBar(int points)
        {
            if(_currentScore <= 0 && points < 0) return;
            if(_currentScore >= 13 && points >0) return;
            
            _currentScore += points;
            _indicator.transform.SetParent(_points[_currentScore].transform);
            _indicator.transform.DOKill();
            Vector3 newPos = new Vector3(0, 25.89999f, -0.5f);
            _indicator.transform.DOLocalMove(newPos, 0.5f);
        }
    }
}
