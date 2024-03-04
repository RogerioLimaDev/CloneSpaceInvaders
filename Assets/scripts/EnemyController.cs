using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    ActionsController actionsController;
    [SerializeField] private GameObject projectile;
    Transform m_transform, leftLimit, rightLimit, bottomLimit;
    bool touchedRightBoundary;
    bool touchedLeftBoundary;
    float fireInterval;


    void Awake()
    {
        actionsController = FindAnyObjectByType<ActionsController>();
    }

    void Start()
    {
        touchedRightBoundary = false;
        touchedLeftBoundary= false;
        m_transform = GetComponent<Transform>();
        leftLimit = GameObject.Find("leftLimit").GetComponent<Transform>();
        rightLimit = GameObject.Find("rightLimit").GetComponent<Transform>();
        bottomLimit = GameObject.Find("bottomLimit").GetComponent<Transform>();

        InvokeRepeating("FireProjectile", 0f, 5.0f);
    }

   void FixedUpdate()
   {
        if(m_transform.position.x > rightLimit.position.x-0.7f && touchedRightBoundary == false)
        {
            // Debug.Log("Touched rigth boundary");
            touchedRightBoundary = true;
            actionsController.ReverseSquadron();
            touchedRightBoundary = false;
        }

        if(m_transform.position.x < leftLimit.position.x+0.8f && touchedLeftBoundary == false)
        {
            // Debug.Log("Touched left boundary");
            touchedLeftBoundary = true;
            actionsController.ReverseSquadron();
            touchedLeftBoundary = false;
        }

        if(m_transform.position.y <= bottomLimit.position.y)
        {
            Debug.Log("Touched bottom boundary");
            actionsController.GameOver();
        }
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
