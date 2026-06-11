/*
* Author: Olivia Chai Yu Tong
* Date: 11/06/2026
* Description: Handles player health.
*/
using UnityEngine;
using UnityEngine.UI;

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
    /// Reduces player health.
    /// </summary>
    /// <param name="damage">The amount of damage to take.</param>
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / 100f;

        Debug.Log("Health: " + Mathf.Round(currentHealth));

        if(currentHealth <= 0)
        {
            Debug.Log("You Died!");
        }
    }
}
