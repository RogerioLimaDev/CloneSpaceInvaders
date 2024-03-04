using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log($"{other.gameObject.name} Collided");
    }

}
