/*
* Author: Olivia Chai Yu Tong
* Date: 11/06/2026
* Description: Handles player health and game over screen.
*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthScript : MonoBehaviour
{
    /// <summary>
    /// Current health of the player.
    /// </summary>
    public float currentHealth = 100f;
    /// <summary>
    /// Reference to the health bar image.
    /// </summary>
    public Image healthBar;

    /// <summary>
    /// Game over panel that appears when the player dies.
    /// </summary>
    public GameObject gameOverPanel;

    /// <summary>
    /// Checks if the player is already dead.
    /// </summary>
    bool isDead = false;

    /// <summary>
    /// Hides the game over panel at the start of the game.
    /// </summary>
    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        Time.timeScale = 1f;
    }

    /// <summary>
    /// Reduces player health.
    /// </summary>
    /// <param name="damage">The amount of damage to take.</param>
    public void TakeDamage(float damage)
    {
        if (isDead)
        {
            return;
        }
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / 100f;

        Debug.Log("Health: " + Mathf.Round(currentHealth));

        if (currentHealth <= 0)
        {
            healthBar.fillAmount = 0;
            GameOver();
        }
    }
    /// <summary>
    /// Shows the game over screen when the user dies.
    /// </summary>
    void GameOver()
    {
        isDead = true;

        Debug.Log("You Died!");

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    /// <summary>
    /// Restarts the current scene when the restart button is clicked.
    /// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

