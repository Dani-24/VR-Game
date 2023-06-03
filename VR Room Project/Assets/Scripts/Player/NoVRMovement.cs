using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NoVRMovement : MonoBehaviour
{
    private Vector2 movement;

    public float speed = 1f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void Update()
    {
        Vector3 movement3d = new Vector3(movement.x * speed, rb.velocity.y, movement.y * speed);
        rb.velocity = transform.TransformDirection(movement3d);
    }
}
