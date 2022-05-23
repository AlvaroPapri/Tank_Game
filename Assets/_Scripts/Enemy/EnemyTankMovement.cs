using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankMovement : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (player == null) return;

        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        transform.LookAt(player.transform.position);
        agent.SetDestination(player.transform.position);
    }
}
