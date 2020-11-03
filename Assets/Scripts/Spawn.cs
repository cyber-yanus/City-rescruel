using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Spawn : MonoBehaviour
    {
        
        [SerializeField] private List<GameObject> spawnObjects;


        private IEnumerator Start()
        {
            while (true)
            {
                Execute();
                yield return new WaitForSeconds(2f);    
            }
        }

        private void Execute()
        {
            int randomNumber = Random.Range(0, spawnObjects.Count-1);
            GameObject car = Instantiate(spawnObjects[randomNumber], transform);
            car.transform.localPosition = Vector3.zero;
            
        }

    }
}