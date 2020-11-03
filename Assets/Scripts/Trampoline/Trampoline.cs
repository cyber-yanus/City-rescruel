using DG.Tweening;
using Lean.Touch;
using UnityEngine;
using UnityEngine.Serialization;


namespace DefaultNamespace
{
    public class Trampoline : MonoBehaviour
    {
        [SerializeField] private float pushDuration;
        [SerializeField] private ParticleSystem particleSystem;

        
        private Rigidbody _rb;
        private MoveHandler _moveHandler;
        private Tween _moveTween;

        private void Start()
        {
            _moveHandler = GetComponent<MoveHandler>();
            _rb = GetComponent<Rigidbody>();
        }

        public void Push(Vector3 targetPosition)
        {
            Debug.Log("push");
            
            transform.parent = null;
            
            _rb.isKinematic = false;
            _rb.AddTorque(Vector3.one * 360,ForceMode.VelocityChange);
            _moveTween = _rb.DOMove(targetPosition, pushDuration).SetEase(Ease.Linear);
        }

        public void Raise()
        {
            _rb.isKinematic = true;
        }

        public void Drop()
        {
            _rb.isKinematic = false;
        }


        private void OnCollisionEnter(Collision other)
        {
            var tag = other.transform.tag;

            if (tag.Equals("Wall"))
            {
                PlayExplosionTrampoline(other.contacts[0].point);
                _moveTween.Kill();
                _moveHandler.enabled = false;
                _rb.isKinematic = true;
            }
        }

        private void PlayExplosionTrampoline(Vector3 position)
        {
            particleSystem.transform.position = position;
            particleSystem.Play();
        }


    }
}