/*
* Author: Olivia Chai Yu Tong
* Date: 11/06/2026
* Description: Damages the player slowly when standing or touching on chocolate lava.
*/

using UnityEngine;

public class ChocolateLava : MonoBehaviour
{
    /// <summary>
    /// Damage dealt to the player every second.
    /// </summary>
    public float damagePerSecond = 10f;

    /// <summary>
    /// Damages the player while the player is touching the lava.
    /// </summary>
    /// <param name="other">The object touching the lava.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthScript health = other.GetComponent<HealthScript>();

            if (health != null)
            {
                health.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }
}
