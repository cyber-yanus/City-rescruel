using UnityEngine;

namespace DefaultNamespace
{
    public class TrampolineConveyor : MonoBehaviour
    {
        [SerializeField] private GameObject trampoline;
        [SerializeField] private int trampolineNumber;

        private void Update()
        {
            CreateTrampoline();
        }

        private void CreateTrampoline()
        {
            int childCount = transform.childCount;

            if (childCount < 1 && trampolineNumber != 0)
            {
                Instantiate(trampoline, transform);
                trampolineNumber--;
            }

        }
        
        
    }
}