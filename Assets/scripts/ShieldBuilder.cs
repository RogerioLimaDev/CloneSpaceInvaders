using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBuilder : MonoBehaviour
{
    [SerializeField] private GameObject pixel, emptyPixel;
    [SerializeField] private int h_size, v_size, doorStart, doorEnd;
    [SerializeField] private float pixelSize;
    Vector2 pixelPosition =  new Vector2(30,30);
    void Start()
    {
        BuildShield();
    }

    void BuildShield() 
    {
        pixelPosition = transform.position;
        GameObject go_pixel;
        
        for (int i = 0; i < v_size; i++)
        {
            for (int j = 0; j < h_size; j++)
            {
                if(i==0 && j==0 || i ==0 && j== h_size-1)
                {
                   go_pixel = Instantiate(emptyPixel,pixelPosition, Quaternion.identity);
                   go_pixel.transform.SetParent(transform);

                }else if(i> v_size-2 && j>doorStart && j<doorEnd)
                {
                    go_pixel = Instantiate(emptyPixel,pixelPosition, Quaternion.identity);
                   go_pixel.transform.SetParent(transform);

                }else
                {
                    go_pixel = Instantiate(pixel,pixelPosition, Quaternion.identity);
                   go_pixel.transform.SetParent(transform);
                }
                pixelPosition.x += pixelSize;
            }

            pixelPosition.x = transform.position.x;
            pixelPosition.y -= pixelSize;
        }

    }

}
