using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class MoveHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {

        [SerializeField] private BoxCollider boxCollider; 
        
        private Trampoline _trampoline;
            
        
        private void Start()
        {
            _trampoline = GetComponent<Trampoline>();
        }

        private Vector3 SelectTargetPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red);
            
            

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                
                return hit.point;    
            }

            return Vector3.zero;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("Drag");
            
            Vector3 selectTargetPosition = SelectTargetPosition();
            transform.localPosition = new Vector3(selectTargetPosition.x, selectTargetPosition.y, 0);
        }


        public void OnEndDrag(PointerEventData eventData)
        {    
            Vector3 targetPosition = SelectTargetPosition();
            _trampoline.Push(targetPosition);
            boxCollider.enabled = true;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            
            
            boxCollider.enabled = false;                    
            _trampoline.Raise();
        }
    }
}