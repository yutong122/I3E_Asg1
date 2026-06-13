/*
* Author: Olivia Chai Yu Tong
* Date: 10/06/2026
* Description: Manages player score and collectible count for Candy Land Escape.
*/
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerCollisionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int score = 0;
    public int collectibleCount = 0;
    public TextMeshProUGUI scoreText;
    GameObject currentCollider;
    public UIManager MyUIManager;
    /// <summary>
    /// Number of collectibles needed before showing the unlock message.
    /// </summary>
    public int firstDoorRequiredCollectibles = 8;
    /// <summary>
    /// Number of collectibles needed before showing the final door unlock message.
    /// </summary>
    public int finalDoorRequiredCollectibles = 15;
    /// <summary>
    /// Checks if the unlock message has already been shown.
    /// </summary>
    bool unlockMessageShown = false;
    bool finalDoorMessageShown = false;

    void OnCollisionEnter(Collision collision)
    {
        currentCollider = collision.gameObject;
        Debug.Log("Collided with " + currentCollider.name);
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == currentCollider)
        {
            currentCollider = null;
        }
    }
    public void ModifyScore(int amount)
    {
        //Increase current Score by the amount passed as an argument
        score += amount;
        MyUIManager.SetScore(score);
    }
    void OnInteract(InputValue value)
    {
        if (currentCollider != null)
        {
            if (currentCollider == null)
            {
                return;
            }
            print($"Interacting with a{currentCollider.name}");
            var collectibles = currentCollider.GetComponent<Collectibles>();
            if (collectibles != null)
            {
                print($"Interacting with a Collectible {currentCollider.name}");
                ModifyScore(collectibles.score);
                collectibles.Collect();

                collectibleCount++;
                MyUIManager.SetCollectibles(collectibleCount);
                Debug.Log("Collectibles Collected: " + collectibleCount);
                if (collectibleCount >= firstDoorRequiredCollectibles && unlockMessageShown == false)
                {
                    MyUIManager.ShowUnlockDoorMessage();
                    unlockMessageShown = true;
                }
                if (collectibleCount >= finalDoorRequiredCollectibles && finalDoorMessageShown == false)
                {
                    MyUIManager.ShowCongratsMessage();
                    finalDoorMessageShown = true;
                }
                currentCollider = null;
                return;
            }
        }
        var door = currentCollider.GetComponentInParent<Door>();

        if (door != null)
        {
            Debug.Log("Interacting with Door");
            if (collectibleCount < door.requiredCollectibles)
            {
                MyUIManager.ShowLockedDoorMessage();
            }
            else
            {
                door.Interact(collectibleCount);
            }
            return;
        }
        Debug.Log("Interacting with " + currentCollider.name);
    }
    public int GetScore()
    {
        return score;
    }

    /// <summary>
    /// Gets the number of collectibles collected by the player.
    /// </summary>
    /// <returns>The number of collectibles collected.</returns>
    public int GetCollectibleCount()
    {
        return collectibleCount;
    }
}


