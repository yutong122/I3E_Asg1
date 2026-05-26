using NUnit.Framework;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 rotateAmount = new Vector3(0, 90f,0);
    bool isOpen = false;
    public void Interact()
    {
        if (isOpen) transform.Rotate( rotateAmount);
        else transform.Rotate(rotateAmount * -1);
        isOpen = !isOpen;
    }
}