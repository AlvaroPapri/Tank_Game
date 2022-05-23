using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    [Header("Attack")]
    public Transform posRotBall;
    public GameObject ballPrefab;
    public float timeBetweenAttacks;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Attack", 3, timeBetweenAttacks);
    }

    private void Attack()
    {
        Instantiate(ballPrefab, posRotBall.position, posRotBall.rotation);
    }
}
