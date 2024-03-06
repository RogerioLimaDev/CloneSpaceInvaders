using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int projectileSpeed;
    public int ProjectileSpeed {set{projectileSpeed = value;}}
    [SerializeField] private GameObject explosion, playerExplosion;
    ActionsController actionsController;
    private Transform topLimit;

    void Awake()
    {
        actionsController = FindAnyObjectByType<ActionsController>();
    }
    void Start()
    {
        Rigidbody myRigidBody;
        topLimit = GameObject.Find("topLimit").GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody>();
        Vector3 projectileForce = new Vector3(0,projectileSpeed,0);
        myRigidBody.AddForce(projectileForce, ForceMode.Force);
    }

    void FixedUpdate()
    {
        if(transform.position.y > topLimit.position.y)
        {
           Destroy(gameObject,0.1f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.tag == "Enemy" )
        {
            Destroy(other.gameObject);
            Instantiate(explosion,other.transform.position, Quaternion.identity);
            actionsController.EnemyDestroyed();
        }
        else
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
            actionsController.PlayerDestroyed();
        }

        Destroy(gameObject,0.1f);
    }
}
