using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    ActionsController actionsController;
    [SerializeField] private GameObject projectile;
    Transform m_transform, leftLimit, rightLimit, bottomLimit;
    bool touchedBoundary;
    float fireInterval;
    string boundary;


    private void Awake()
    {
        actionsController = FindAnyObjectByType<ActionsController>();
    }

    void OnEnable()
    {
        actionsController.boundaryTouched += BoundaryTouched;
    }

    void OnDisable()
    {
        actionsController.boundaryTouched -= BoundaryTouched;
        
    }

    private void BoundaryTouched()
    {
        touchedBoundary = true;
        Invoke("ResetTouchBool", 1.0f);
    }


    private void Start()
    {
        touchedBoundary = false;
        m_transform = GetComponent<Transform>();
        leftLimit = GameObject.Find("leftLimit").GetComponent<Transform>();
        rightLimit = GameObject.Find("rightLimit").GetComponent<Transform>();
        bottomLimit = GameObject.Find("bottomLimit").GetComponent<Transform>();
        InvokeRepeating("FireProjectile", 0f, 5.0f);
    }

   private void LateUpdate()
   {
        if(!m_transform)
            return;

        CheckBoundary();
   }

   private void CheckBoundary() 
   {
        if(touchedBoundary == false && m_transform.position.x > rightLimit.position.x-0.7f && boundary != "right")
        {
            boundary = "right";
        }
        else if(touchedBoundary == false && m_transform.position.x < leftLimit.position.x+0.8f && boundary !="left")
        {
            boundary = "left";
        }
        else if(touchedBoundary == false && m_transform.position.y <= bottomLimit.position.y  && boundary !="bottom")
        {
            boundary = "bottom";
        }else
        {
            return;
        }

        if(boundary == "right" || boundary =="left")
        {
            actionsController.BoundaryTouched();
            actionsController.ReverseSquadron();
        }

        if(boundary == "bottom")
        {
            actionsController.GameOver();
        }

        switch (boundary)
        {
            case "left":
                Debug.Log($"{this.gameObject.name} touched left boundary");
            break;

            case "right":
                Debug.Log($"{this.gameObject.name} touched rigth boundary");
            break;

            case "bottom":
                Debug.Log($"{this.gameObject.name} touched bottom boundary");
            break;
            
            default:
            break;
        }
   }

   private void ResetTouchBool() 
   {
        touchedBoundary = false;
   }

   private void FireProjectile() 
   {
        fireInterval = UnityEngine.Random.Range(5, 300.0f);
        StartCoroutine("InstantiateProjectile");
   }

   IEnumerator InstantiateProjectile() 
   {
        yield return new WaitForSeconds(fireInterval);
        GameObject currentProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        Projectile currentBullet = currentProjectile.GetComponent<Projectile>();
        currentBullet.ProjectileSpeed = UnityEngine.Random.Range(-30, -60);
   }
}
