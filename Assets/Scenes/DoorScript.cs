/*
* Author: Olivia Chai Yu Tong
* Date: 11/06/2026
* Description: Opens the door only when the player has enough collectibles.
*/

using UnityEngine;

public class Door : MonoBehaviour
{
    /// <summary>
    /// Number of collectibles needed to open this door.
    /// </summary>
    public int requiredCollectibles = 1;

    /// <summary>
    /// How much my door moves when opened.
    /// </summary>

    public Vector3 rotateAmount = new Vector3(0, 90f, 0);
    /// <summary>
    /// Checks if the door is already opened.
    /// </summary>

    /// <summary>
    /// The collider that blocks the player when the door is closed.
    /// This will be disabled when the door opens so that the player can walk through.
    /// </summary>
    public Collider doorBlocker;

    bool isOpen = false;
    public void Interact(int playerCollectibles)
    {
        Debug.Log("Player collectibles: " + playerCollectibles);
        Debug.Log("Required collectibles: " + requiredCollectibles);
        if (playerCollectibles < requiredCollectibles)
        {
            Debug.Log("Door is locked. You need more collectibles.");
            return;
        }
        if (isOpen)
        {
            transform.Rotate(rotateAmount * -1);
            // Turn the door collider back on so the player cannot walk through
            if (doorBlocker != null)
            {
                doorBlocker.enabled = true;
            }
            Debug.Log("Door closed");
        }
        else
        {
            transform.Rotate(rotateAmount);
            // Play the door opening sound.
            AudioSource audio = GetComponent<AudioSource>();
            if (audio != null)
            {
                audio.Play();
            }

            // Turn the door collider off so the player can walk through
            if (doorBlocker != null)
            {
                doorBlocker.enabled = false;
            }

            Debug.Log("Door opened");
        }
        isOpen = !isOpen;
    }
}

