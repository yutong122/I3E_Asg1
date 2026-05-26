using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        print("Collison Detected!");
        print($"Collided with:{ collision.gameObject.name}");
    }
}

///foreach(ContactPoint contact in collision.contacts){
     ///       Debug.DrawRay(contact.point,contact.normal,Color.white);
        ///}