using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelCollisionController : MonoBehaviour
{

    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("Collided!");
        Destroy(gameObject);
        
    }
}
