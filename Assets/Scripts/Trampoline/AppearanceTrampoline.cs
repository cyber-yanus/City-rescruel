using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class AppearanceTrampoline : MonoBehaviour
    {
        [SerializeField] private Vector3 endPosition;


        private void Start()
        {
            Appearance();
        }

        private void Appearance()
        {
            transform.DOLocalMove(endPosition, 1f);
        }
    }
}