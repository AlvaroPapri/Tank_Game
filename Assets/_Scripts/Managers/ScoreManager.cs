using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int enemiesLeft;
    public WinManager WinManager;
    
    public static ScoreManager Instance;

    private void Start()
    {
        Instance = this;
        scoreText.text = " x " + enemiesLeft;
    }

    public void EnemyDown()
    {
        enemiesLeft -= 1;
        scoreText.text = " x " + enemiesLeft;

        if (enemiesLeft <= 0)
        {
            WinManager.Setup();
            enemiesLeft = 0;
        }
    }
}
