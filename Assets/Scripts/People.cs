using UnityEditor.SceneManagement;
using UnityEngine;

namespace DefaultNamespace
{
    public class People : MonoBehaviour
    {
        private HingeJoint _hingeJoint;
        private Rigidbody _rb;

        private void Start()
        {
            _hingeJoint = GetComponent<HingeJoint>();
            _rb = GetComponent<Rigidbody>();
        }


        private void OnCollisionEnter(Collision other)
        {
            var tag = other.transform.tag;

            if (tag.Equals("Player"))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.position = new Vector3(transform.position.x, transform.position.y, 4.8f);
                
                _rb.useGravity = true;
                _rb.isKinematic = false;
            }            
        }
        
        
    }
}