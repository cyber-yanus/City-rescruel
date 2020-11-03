using UnityEngine;

namespace DefaultNamespace
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private Vector3 direction;
        [SerializeField] private float speed;
        
        private Rigidbody _rb;
        private MoveHandler _moveHandler;


        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _moveHandler = GetComponent<MoveHandler>();
        }

        private void Update()
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}