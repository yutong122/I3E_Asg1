using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int score= 0;
    int collectibles = 0;
    public TMP_Text ScoreText;
    public TMP_Text CollectiblesText;

    public GameObject Menupanel;


    void Start()
    {
        ScoreText.text = "Score: 0";
        CollectiblesText.text = "Collectibles Collected: 0/20";
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text= "Score:" + score; 
        CollectiblesText.text = "Collectibles Collected: " + collectibles + "/20";   
    }
    
    public void IncrementScore(int newScore)
    {
        score ++;

    }

    public void SetScore(int newScore)
    {
        score = newScore;
    }
    public void SetCollectibles(int newCollectibles)
    {
        collectibles = newCollectibles;
    }

    public void ShowMenu(bool isVisible)
    {
        Menupanel.SetActive(isVisible);
        Cursor.lockState = isVisible?
            CursorLockMode.None : 
            CursorLockMode.Locked; 
    }
}
