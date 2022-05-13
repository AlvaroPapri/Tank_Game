using System;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    [Header("Movement")]
    public int speed;
    public int turnSpeed;
    
    [Header("Attack")] 
    public GameObject prefab;
    public Transform posRotCanonBall;

    private void Update()
    {
        Move();
        Attack();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.forward * (v * speed * Time.deltaTime));
        transform.Rotate(Vector3.up * (h * turnSpeed * Time.deltaTime));
    }
    
    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab, posRotCanonBall.position, posRotCanonBall.rotation);
        }
    }
}
