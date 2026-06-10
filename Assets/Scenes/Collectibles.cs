/*
* Author: Olivia Chai Yu Tong
* Date: 10/06/2026
* Description: Make the items collectible and disappear after collecting
*/

using UnityEngine;

public class Collectibles : MonoBehaviour
{
    /// The score value added when this collectible is collected.
    public int score = 1;

    /// Detects when the player touches the collectible using Unity Physics.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCollisionScript player = other.GetComponent<PlayerCollisionScript>();
            if (player != null)
            {
                player.ModifyScore(score);
            }
            Debug.Log("Collected! Score:"+ score);
            Collect();
        }
    }
    /// Plays sound, hides the collectible, disables its collider, and destroys it.
    public void Collect()
    {
        //Play the coin collect sound
        var audio = GetComponent<AudioSource>();
        audio.Play();
        //Hide the coin
        var renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
        //Destroy the coin after 1 second
        Destroy(gameObject, 1);
    }
}
