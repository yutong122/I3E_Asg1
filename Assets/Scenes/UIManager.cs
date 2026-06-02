using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int score= 0;
    public TMP_Text ScoreText;

    public GameObject Menupanel;


    void Start()
    {
        ScoreText.text = "0";

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text= $"{score}";    
    }
    
    public void IncrementScore(int newScore)
    {
        score ++;

    }

    public void SetScore(int newScore)
    {
        score = newScore;
    }

    public void ShowMenu(bool isVisible)
    {
        Menupanel.SetActive(isVisible);
        Cursor.lockState = isVisible?
            CursorLockMode.None : 
            CursorLockMode.Locked; 
    }
}
