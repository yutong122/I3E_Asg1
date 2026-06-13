/*
* Author: Olivia Chai Yu Tong
* Date: 13/06/2026
* Description: Second hazard in area 2.
*/
using UnityEngine;
public class Area2Hazard : MonoBehaviour
{
    /// <summary>
    /// Damage dealt to the player every second.
    /// </summary>
    public float damagePerSecond = 10f;

    /// <summary>
    /// Damages the player while the player is touching the hazard.
    /// </summary>
    /// <param name="other">The object touching the hazard.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthScript health = other.GetComponent<HealthScript>();

            if (health != null)
            {
                health.isInArea2 = true;
                health.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }
}