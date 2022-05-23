using UnityEngine;

public class EnemyTankShooting : MonoBehaviour
{
    [Header("Attack")]
    public Transform posRotBall;
    public GameObject ballPrefab;
    public float timeBetweenAttacks;
    
    [Header("Target")]
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Attack", 3, timeBetweenAttacks);
    }

    private void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
    }

    private void Attack()
    {
        Instantiate(ballPrefab, posRotBall.position, posRotBall.rotation);
    }
}
