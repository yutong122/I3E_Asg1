/*
* Author: Olivia Chai Yu Tong
* Date: 13/06/2026
* Description: Shows the final game results when the player reaches the end.
*/
using UnityEngine;
using TMPro;

public class EndGameTrigger : MonoBehaviour
{
    public GameObject gameEndPanel;
    public TMP_Text finalScoreText;
    public TMP_Text finalCollectiblesText;
    public TMP_Text finalDeathCountText;
    bool gameEnded = false;

    void Start()
    {
        if (gameEndPanel != null)
        {
            gameEndPanel.SetActive(false);
        }
    }
    /// <summary>
    /// Shows the final result screen when the player enters the trigger.
    /// </summary>
    /// <param name="other">The object that enters the trigger.</param>
    void OnTriggerEnter(Collider other)
    {
        if (gameEnded == true)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            gameEnded = true;

            PlayerCollisionScript playerStats = other.GetComponent<PlayerCollisionScript>();
            HealthScript health = other.GetComponent<HealthScript>();

            gameEndPanel.SetActive(true);

            finalScoreText.text = "Final Score: " + playerStats.GetScore();
            finalCollectiblesText.text = "Collectibles Collected: " + playerStats.GetCollectibleCount() + "/20";
            finalDeathCountText.text = "Deaths: " + health.deathCount;

            var audio = GetComponent<AudioSource>();
            audio.Play();

            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

