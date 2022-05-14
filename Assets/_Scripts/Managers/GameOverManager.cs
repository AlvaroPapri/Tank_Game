using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public bool isGameOver;

    private void Start()
    {
        isGameOver = false;
    }

    public void Setup(int enemiesLeft)
    {
        Time.timeScale = 0;
        isGameOver = true;
        gameObject.SetActive(true);
        scoreText.text = "You left " + enemiesLeft.ToString() + " enemies";
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level");
    }

    public void MainMenuButton()
    {
        
    }
}
