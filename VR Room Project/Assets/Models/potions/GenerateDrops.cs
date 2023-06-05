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

    private Vector3 downDirection;
    private Vector3 objectDirection;

    public int dropMax;
    public int dropCount;
    public bool isReset;

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
                timer = 0.0f;
            }
        }
        else
        {
            timer = 0.0f;
        }
    }
}
