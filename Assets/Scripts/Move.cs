using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    
    
    void Start()
    {
        
    }

    private void Update()
    {
        Execute();
    }

    private void Execute()
    {    
        transform.position += Vector3.forward * speed * Time.deltaTime ;
    }
}
