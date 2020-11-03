using UnityEngine;

namespace DefaultNamespace
{
    public class TargetPosition : MonoBehaviour
    {
        [SerializeField] private Transform people;

        private int _currentChildNumber;


        private void Start()
        {
            UpdateTargetPosition();
        }


        public void UpdateTargetPosition()
        {
            if (_currentChildNumber < people.childCount) 
            {
                Vector2 newPosition = people.GetChild(_currentChildNumber).position;
                transform.position = new Vector3(newPosition.x, newPosition.y, 4.5f);

                _currentChildNumber++;    
            }
        }

    }
}