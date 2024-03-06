using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform cannon, player;
    float playerInput = 0;
    Vector3 playerMovement;
    ActionsController actionsController;

    void Awake()
    {
        actionsController = FindAnyObjectByType<ActionsController>();
    }

    void Start()
    {
        playerMovement = new Vector3(playerInput, 0, 0);
        player = GetComponent<Transform>();
    }
    void Update()
    {
        MovePlayer() ;
        if(Input.GetButtonUp("Jump"))
        {
            FireProjectile();
        }
    }

    void MovePlayer() 
    {
        playerInput = Input.GetAxis("Horizontal")*playerSpeed*Time.deltaTime;
        playerMovement.x = playerInput;
        player.Translate(playerMovement, Space.World);
    }

    void FireProjectile() 
    {
        GameObject currentProjectile =Instantiate(projectile,cannon.position, Quaternion.identity);
        Projectile currentBullet = currentProjectile.GetComponent<Projectile>();
        actionsController.PlayFireSound();
        currentBullet.ProjectileSpeed = 20;
    }
}
