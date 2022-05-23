using System;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [Header("Movement")]
    public int speed;
    public int turnSpeed;
    public int headTurnSpeed;
    private Rigidbody rb;

    private float horizontal;
    private float vertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * (vertical * speed * Time.deltaTime);
        rb.MovePosition(transform.position + movement);
    }

    private void Turn()
    {
        float turn = horizontal * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(transform.rotation * turnRotation);
    }
}
