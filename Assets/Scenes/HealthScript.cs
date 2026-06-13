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
    /// Area 1 death shows the game over panel and allows restart.
    /// Area 2 death shows a short popup and respawns the player without restarting the scene.
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
    /// Popup panel that appears shortly when the player dies in Area 2.
    /// </summary>
    public GameObject area2DeathPopupPanel;

    /// <summary>
    /// Audio source used to play death sounds.
    /// </summary>
    public AudioSource audioSource;

    /// <summary>
    /// Sound played when the player dies in Area 1.
    /// </summary>
    public AudioClip gameOverSound;

    /// <summary>
    /// Sound played when the player dies in Area 2.
    /// </summary>
    public AudioClip respawnSound;


    /// <summary>
    /// The point where the player respawns in Area 2.
    /// </summary>
    public Transform area2RespawnPoint;

    /// <summary>
    /// Checks whether the player is currently in Area 2.
    /// If true, the player will respawn instead of getting game over.
    /// </summary>
    public bool isInArea2 = false;


    /// <summary>
    /// Checks if the player is already dead.
    /// </summary>
    bool isDead = false;

    /// <summary>
    /// Number of times the player has died.
    /// </summary>
    public int deathCount = 0;

    /// <summary>
    /// Hides the game over panel at the start of the game.
    /// </summary>
    void Start()
    {
        isInArea2 = false;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        if (area2DeathPopupPanel != null)
        {
            area2DeathPopupPanel.SetActive(false);
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

            if (isInArea2)
            {
                Area2Death();
            }
            else
            {
                GameOver();
            }
        }
    }
    /// <summary>
    /// Shows the Area 2 death popup for 1.5 seconds before respawning the player.
    /// </summary>
    void Area2Death()
    {
        isDead = true;
        deathCount++;
        Debug.Log("You died in Area 2. Showing respawn popup...");

        if (area2DeathPopupPanel != null)
        {
            area2DeathPopupPanel.SetActive(true);
        }
        if (audioSource != null && respawnSound != null)
        {
            audioSource.PlayOneShot(respawnSound);
        }

        Invoke("RespawnInArea2", 1.5f);
    }
    /// <summary>
    /// Respawns the player at the Area 2 respawn point without restarting the scene.
    /// This allows the score and collectibles to remain saved.
    /// </summary>
    void RespawnInArea2()
    {
        if (area2DeathPopupPanel != null)
        {
            area2DeathPopupPanel.SetActive(false);
        }
        Debug.Log("You died in Area 2. Respawning...");

        CharacterController controller = GetComponent<CharacterController>();

        if (controller != null)
        {
            controller.enabled = false;
        }

        if (area2RespawnPoint != null)
        {
            transform.position = area2RespawnPoint.position;
            transform.rotation = area2RespawnPoint.rotation;
        }

        if (controller != null)
        {
            controller.enabled = true;
        }

        currentHealth = 100f;

        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / 100f;
        }

        isDead = false;
    }
    /// <summary>
    /// Shows the game over screen when the user dies.
    /// </summary>
    void GameOver()
    {
        isDead = true;
        deathCount++;
        Debug.Log("You Died!");
        if (audioSource != null && gameOverSound != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }

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

