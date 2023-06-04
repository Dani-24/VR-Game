using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDrops : MonoBehaviour
{

    [SerializeField] private Transform drop;
    [SerializeField] private Transform dropSpawner;
    [SerializeField] private float degreesToDrop;
    [SerializeField] private float dropSeconds;
    private float timer;

    Vector3 downDirection;
    Vector3 objectDirection;


    void Start() 
    {
        downDirection = Vector3.down;
    }

    void Update()
    {
        timer += Time.deltaTime;

        objectDirection = transform.up;

        Debug.DrawRay(transform.position, objectDirection * 100, Color.blue);

        float dotProduct = Vector3.Dot(downDirection.normalized, objectDirection.normalized);

        if (dotProduct > degreesToDrop) 
        {
            if (timer > dropSeconds) 
            {
                Transform dropInstance = Instantiate(drop, dropSpawner.position, dropSpawner.rotation, dropSpawner);
               // dropInstance.parent = dropSpawner.transform;
                //   dropInstance.localScale = 
                //  dropInstance.parent = dropSpawner.transform;
                timer = 0.0f;
            }
            
            // El objeto está mirando hacia abajo
            Debug.Log("El objeto está mirando hacia abajo.");
        }
        else
        {
            timer = 0.0f;
            // El objeto no está mirando hacia abajo
            Debug.Log("El objeto no está mirando hacia abajo.");
        }
    }
}
