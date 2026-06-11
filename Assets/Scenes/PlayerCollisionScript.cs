/*
* Author: Olivia Chai Yu Tong
* Date: 10/06/2026
* Description: Manages player score and collectible count for Candy Land Escape.
*/
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class PlayerCollisionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int score = 0;
    public int collectibleCount = 0;
    public TextMeshProUGUI scoreText;
    GameObject currentCollider;
    public UIManager MyUIManager;
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
                currentCollider = null;
                return;
            }
        }
        var door = currentCollider.GetComponentInParent<Door>();

        if (door != null)
        {
            Debug.Log("Interacting with Door");
            door.Interact(collectibleCount);
            return;
        }

        Debug.Log("Interacting with " + currentCollider.name);
    }
}












/*

using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class PlayerCollisionScript : MonoBehaviour
{
    /// <summary>
    /// The starting score of the player
    /// </summary>
    public int score = 0;

    /// <summary>
    /// The number of collectibles collected by the player.
    /// </summary>
    public int collectibleCount = 0;
    bool isMenuShowing = false;
    public UIManager MyUIManager;
    void OnMenu()
    {
        MyUIManager.ShowMenu(isMenuShowing);
        isMenuShowing = !isMenuShowing;
    }
    /// <summary>
    /// Adds score and increases collectible count.
    /// </summary>
    /// <param name="amount">The score amount to add.</param>

    public void ModifyScore(int amount)
    {
        //Increase current Score by the amount passed as an argument
        score += amount;
        MyUIManager.SetScore(score);


    }

void OnCollisionEnter(Collision collision)
    {
        currentCollider = collision.gameObject;

        Debug.Log("Collided with " + currentCollider.name);

        Collectibles collectible = currentCollider.GetComponent<Collectibles>();

        if (collectible != null)
        {
            Debug.Log("This is a collectible. Press E to collect it.");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == currentCollider)
        {
            Debug.Log("Stopped colliding with " + currentCollider.name);
            currentCollider = null;
        }
    }


    void OnInteract(InputValue value)
    {
        if (currentCollider != null)
        {
            var collectible = currentCollider.GetComponent<Collectible>();
            if (collectible != null)
            {
                Debug.Log($"Interacting with " + currentCollider.name);
                ModifyScore(collectible.score);
                collectible.Collect();

                currentCoinCount++;
                //Update the coin tracking icon
                if (currentCoinCount >= coinTrackingSprites.Length)
                {
                    currentCoinCount = coinTrackingSprites.Length - 1;
                }
                coinTrackingIcon.sprite = coinTrackingSprites[currentCoinCount];
            }
        }
        var door = currentCollider.GetComponent<Door>();
        if (door != null)
        {
            print($"Interacting with Door {currentCollider.name}");
            door.Interact();
        }

    }
    /// <summary>
    /// Triggers when the player touches the finish platform  
    /// </summary>
    /// <param name="other"></param> Other object that the player collides with
    void OnTriggerEnter(Collider other)
    {
        if (score == 17)
        {
            print("Congrats!");
            print($"Final Score:{score}");
        }
    }
    */

