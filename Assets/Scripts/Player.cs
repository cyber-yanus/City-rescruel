using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;


namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        public UnityEvent cameraEvent;
        
        [SerializeField] private TargetPosition jumpTarget;
        [SerializeField] private float jumpDuration;
        [SerializeField] private float jumpPower;
        
        [SerializeField] private ParticleSystem particleSystem;
        
        
        private Rigidbody _rb;
        private Tween _jumpTween;
        
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            var tag = other.transform.tag;

            if (tag.Equals("Trampoline"))
            {
                _rb.isKinematic = true;
                Jump();
                PlayJumpParticle(other.contacts[0].point);
            }
        }

        private void Jump()
        {
            _jumpTween.Kill();
            
            Vector3 endPosition = jumpTarget.transform.position;
            _jumpTween = transform.DOJump(endPosition, jumpPower, 0, jumpDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() => { _rb.isKinematic = false; });
            
            jumpTarget.UpdateTargetPosition();
            cameraEvent.Invoke();
        }

        private void PlayJumpParticle(Vector3 position)
        {
            particleSystem.transform.position = position;
            particleSystem.Play();
        }

    }
}