using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,0.2f));
        print("hello");
    }
}
