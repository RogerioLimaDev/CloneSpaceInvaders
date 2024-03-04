using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player, playerSpawnPoint, squadronParent;
    [SerializeField] private List<GameObject> ships;
    [SerializeField] private Transform shipInitialPoint;
    [SerializeField] private int squadronHSize, squadronVSize;
    [SerializeField] float shipDistance;
    private ActionsController actionsController;
    private int playerScore;
    private int playerLives;
    private GameObject ship;
    public int PlayerScore {get{return playerScore;}}

    private void Awake() 
    {
        actionsController = FindAnyObjectByType<ActionsController>();
    }

    void OnEnable()
    {
        actionsController.gameOver += GameOver;
        actionsController.enemyDestroyed += IncreaseScore;
        actionsController.playerDestroyed += PlayerWasHit;
    }

    void OnDisable()
    {
        actionsController.gameOver -= GameOver;
        actionsController.enemyDestroyed -= IncreaseScore;
        actionsController.playerDestroyed -= PlayerWasHit;
    }

    void Start()
    {
        playerLives = 3;
        SpawnSquadron();
        SpawnPlayer();
    }

    void PlayerWasHit() 
    {
        playerLives--;
        Invoke("SpawnPlayer", 0.8f);
        actionsController.UpdatePlayerLives(playerLives);
    }

    void SpawnPlayer() 
    {
        if(playerLives> 0)
        {
            Instantiate(player, playerSpawnPoint.transform.position, Quaternion.identity);
        }else if(playerLives== 0)
        {
            actionsController.GameOver();
        }
    }

    private void IncreaseScore() 
    {
        playerScore += 50;
    }

    private void GameOver()
    {
        Time.timeScale = 0.0f;
    }
    void SpawnSquadron() 
    {
        Vector2 shipPosition = new Vector2();
        shipPosition.x = shipInitialPoint.transform.position.x;
        shipPosition.y = shipInitialPoint.transform.position.y;
        int k = 0;

        for (int j = 0; j < squadronVSize; j++)
        {
            ship = ships[k];
            k++;
            if(k>ships.Count-1)
            {
                k=0;
            }

            for (int i = 0; i < squadronHSize; i++)
            {
                GameObject newShip = Instantiate(ship, shipPosition, Quaternion.identity);
                shipPosition.x += shipDistance;
                newShip.transform.parent = squadronParent.GetComponent<Transform>();
            }
            shipPosition.x = shipInitialPoint.transform.position.x;
            shipPosition.y -= shipDistance;
            
        }

    }
}
