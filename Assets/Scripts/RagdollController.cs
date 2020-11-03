using UnityEngine;

namespace DefaultNamespace
{
    public class RagdollController : MonoBehaviour
    {
        [SerializeField] private Rigidbody[] _rigidbodies;
         
        private void Awake()
        {
            DeactivateRagdoll(true);
        }


        public void DeactivateRagdoll(bool activate)
        {
            foreach (var rigidbody in _rigidbodies)
            {
                rigidbody.isKinematic = activate;
            }
        }
        
        
    }
}