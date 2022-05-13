using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTankHealth : MonoBehaviour
{
    [Header("Health Parameters")] 
    public float maxHealth;
    public float currentHealth;
    public float ballDamage;
    public Image lifeBar;

    private void Start()
    {
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBall"))
        {
            currentHealth -= ballDamage;
            lifeBar.fillAmount = currentHealth / maxHealth;
            Destroy(other.gameObject);

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                ScoreManager.Instance.EnemyDown();
            }
        }
    }
}
