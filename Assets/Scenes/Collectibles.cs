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

    /// Plays sound, hides the collectible, disables its collider, and destroys it.
    public void Collect()
    {
        //Play the collect sound
        var audio = GetComponent<AudioSource>();
        audio.Play();
        //Hide the collectibles
        var renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
        // Disable the collider so the player cannot collect it again.
        var collider = GetComponent<Collider>();
        collider.enabled = false;
        //Destroy the collectible after 1 second
        Destroy(gameObject, 1);
    }
}
