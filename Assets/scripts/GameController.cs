using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player, playerSpawnPoint, squadronParent;
    [SerializeField] private List<GameObject> ships;
    [SerializeField] private Transform shipInitialPoint;
    [SerializeField] private int squadronHorizontalSize, squadronVerticalSize;
    [SerializeField] float shipDistance;
    [SerializeField] int squadronSpeedChangeRate;
    private float currentSquadronSpeed;
    int squadronSize;
    private ActionsController actionsController;
    private int playerScore;
    private int playerLives;
    private GameObject ship;
    private List<GameObject> squadron = new List<GameObject>();
    public int PlayerScore {get{return playerScore;}}
    private int changeSpeedThreshold;

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
        currentSquadronSpeed = 0.5f;
    }

    public void Restart() 
    {
        SceneManager.UnloadSceneAsync(0);
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;

    }


    private void IncreaseSquadronSpeed()
    {
        if(currentSquadronSpeed > 0)
        {
            currentSquadronSpeed -= 0.1f;
        }

        SetSquadronSpeed(currentSquadronSpeed);
        changeSpeedThreshold = squadronSize - squadronSpeedChangeRate;
        Debug.Log($"<color=yellow>Squadron speed is {currentSquadronSpeed}</color>");
    }

    private void SetSquadronSpeed(float speed)
    {
        actionsController.SetSquadronSpeed(speed);
    }


    void PlayerWasHit() 
    {
        playerLives--;
        Invoke("SpawnPlayer", 1.0f);
        actionsController.PlayExplosionSound();
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
        actionsController.PlayInvadersKilledSound();
        
        if(squadron.Count >0)
        {
           squadronSize --;
        }
        else
        {
            SpawnSquadron();
        }
        if(squadronSize == changeSpeedThreshold)
        {
            IncreaseSquadronSpeed();
        }
        Debug.Log($"<color=green>Squadron Size: {squadronSize}</color>");
        Debug.Log($"change speed at squadron size: {changeSpeedThreshold}");
    }

    private void GameOver()
    {
        Time.timeScale = 0.0f;
        GameData gd = new();
        gd.players = new List<string>();
        gd.scores = new List<int>();
        gd.players.Add("");
        gd.scores.Add(playerScore);
        actionsController.SetHighScore(gd);
    }

    void SpawnSquadron() 
    {
        Vector2 shipPosition = new Vector2();
        shipPosition.x = shipInitialPoint.transform.position.x;
        shipPosition.y = shipInitialPoint.transform.position.y;
        int k = 0;

        for (int j = 0; j < squadronVerticalSize; j++)
        {
            ship = ships[k];
            k++;
            if(k>ships.Count-1)
            {
                k=0;
            }

            for (int i = 0; i < squadronHorizontalSize; i++)
            {
                GameObject newShip = Instantiate(ship, shipPosition, Quaternion.identity);
                shipPosition.x += shipDistance;
                newShip.transform.parent = squadronParent.GetComponent<Transform>();
                squadron.Add(newShip);
            }
            shipPosition.x = shipInitialPoint.transform.position.x;
            shipPosition.y -= shipDistance;
        }
        squadronSize = squadron.Count;
        changeSpeedThreshold = squadronSize - squadronSpeedChangeRate;
        SetSquadronSpeed(currentSquadronSpeed);
        Debug.Log($"Squadron Size: {squadronSize}");

    }
}
