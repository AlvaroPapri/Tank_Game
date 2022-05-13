using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    [Header("Movement")]
    public int speed;
    public float distanceToPlayer;
    
    [Header("Attack")]
    public Transform posRotBall;
    public GameObject ballPrefab;
    public float timeBetweenAttacks;
    
    [Header("Target")]
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Attack", 3, timeBetweenAttacks);
    }

    void Update()
    {
        if(!player.IsDestroyed()) MoveToPlayer();
    }

    void MoveToPlayer()
    {
        transform.LookAt(player.transform.position);

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > distanceToPlayer)
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
    }

    void Attack()
    {
        Instantiate(ballPrefab, posRotBall.position, posRotBall.rotation);
    }
}
