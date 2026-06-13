/*
* Author: Olivia Chai Yu Tong
* Date: 13/06/2026
* Description: Detects when the player enters Area 2.
*/
using UnityEngine;

public class Area2Trigger : MonoBehaviour
{
    /// <summary>
    /// Runs when another object enters the Area 2 floor trigger.
    /// </summary>
    /// <param name="other">The object entering the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthScript health = other.GetComponent<HealthScript>();

            if (health != null)
            {
                health.isInArea2 = true;
                Debug.Log("Player entered Area 2.");
            }
        }
    }
}
