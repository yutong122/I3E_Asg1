using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int score = 0;
    int collectibles = 0;
    public TMP_Text ScoreText;
    public TMP_Text CollectiblesText;
    public TMP_Text LockedDoorText;
    public TMP_Text UnlockDoorText;

    public void ShowLockedDoorMessage()
    {
        LockedDoorText.gameObject.SetActive(true);
        UnlockDoorText.gameObject.SetActive(false);

        CancelInvoke("HideDoorMessages");
        Invoke("HideDoorMessages", 2f);
    }
    /// <summary>
    /// Shows the unlock door message for a short time.
    /// </summary>
    public void ShowUnlockDoorMessage()
    {
        LockedDoorText.gameObject.SetActive(false);
        UnlockDoorText.gameObject.SetActive(true);

        CancelInvoke("HideDoorMessages");
        Invoke("HideDoorMessages", 2f);
    }
    /// <summary>
    /// Hides both door message texts.
    /// </summary>
    void HideDoorMessages()
    {
        LockedDoorText.gameObject.SetActive(false);
        UnlockDoorText.gameObject.SetActive(false);
    }


    void Start()
    {
        ScoreText.text = "Score: 0";
        CollectiblesText.text = "Collectibles Collected: 0/20";
        LockedDoorText.gameObject.SetActive(false);
        UnlockDoorText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + score;
        CollectiblesText.text = "Collectibles Collected: " + collectibles + "/20";
    }

    public void IncrementScore(int newScore)
    {
        score++;

    }

    public void SetScore(int newScore)
    {
        score = newScore;
    }
    public void SetCollectibles(int newCollectibles)
    {
        collectibles = newCollectibles;
    }

}
