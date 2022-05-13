using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    [Header("Health Parameters")] 
    public float maxHealth;
    public float currentHealth;
    public float ballDamage;
    public Image lifeBar;

    public GameOverManager GameOverManager;

    private void Start()
    {
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBall"))
        {
            currentHealth -= ballDamage;
            lifeBar.fillAmount = currentHealth / maxHealth;
            Destroy(other.gameObject);

            if (currentHealth <= 0)
            {
                GameOverManager.Setup(ScoreManager.Instance.enemiesLeft);
            }
        }
    }
}
