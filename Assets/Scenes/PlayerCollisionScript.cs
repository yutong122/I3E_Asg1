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
        collectibleCount++;
        MyUIManager.SetScore(score);
        MyUIManager.SetCollectibles(collectibleCount);
    }
/*
    void OnCollisionEnter(Collision collision)
    {
        currentCollider = collision.gameObject;
        print($"Collided with {currentCollider.name}");
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            print($"Stopped colliding with {currentCollider.name}");
            currentCollider = null;
        }
    }


    void OnInteract(InputValue value)
    {
        if (currentCollider != null)
        {
            print($"Interacting with a{currentCollider.name}");

            var collectible = currentCollider.GetComponent<Collectible>();
            if (collectible != null)
            {
                print($"Interacting with a Collectible {currentCollider.name}");
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
}
