using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform people;
        [SerializeField] private float moveDuration; 
        
        
        private int _currentChildNumber;
        private Tween _moveTween; 

        private void Start()
        {
            UpdateTargetPosition();
        }


        public void UpdateTargetPosition()
        {
            if (_currentChildNumber < people.childCount) 
            {
                _moveTween.Kill();
                
                float endPositionY = people.GetChild(_currentChildNumber).position.y;
                _moveTween = transform.DOMoveY(endPositionY, moveDuration);

                _currentChildNumber++;    
            }
        }

    }
}