using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] posSpawn;
    public GameOverManager GameOverManager;
    public int secondsBetweenSpawn;
    public bool stopSpawning;

    private int _randomSpawn;

    private void Start()
    {
        Invoke("SpawnEnemy", secondsBetweenSpawn);
    }

    void SpawnEnemy()
    {
        _randomSpawn = Random.Range(0, posSpawn.Length - 1);

        Instantiate(enemyPrefab, posSpawn[_randomSpawn].position, posSpawn[_randomSpawn].rotation);
        
        if (!GameOverManager.isGameOver && !stopSpawning) Invoke("SpawnEnemy", secondsBetweenSpawn);
    }
}
