using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] private Vector3 endRotationPosition;
        [SerializeField] private float rotateDuration;
        
        private void Start()
        {
            transform.DOLocalRotate(endRotationPosition, rotateDuration, RotateMode.WorldAxisAdd)
                .SetEase(Ease.Linear)
                .SetLoops(-1);
        }
    }
}