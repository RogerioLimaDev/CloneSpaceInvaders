using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimationContrroller : MonoBehaviour
{
    [SerializeField] private Sprite frame1, frame2;
    Sprite currentSprite;

    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>().sprite;
        currentSprite = frame1;
        InvokeRepeating("AnimateShip", 0, 0.5f);
    }

    void AnimateShip()
    {

        if(currentSprite == frame1)
        {
            currentSprite = frame2;
        }else
        {
            currentSprite = frame1;
        }

    }

}
