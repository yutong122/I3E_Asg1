using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int score = 1;
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

