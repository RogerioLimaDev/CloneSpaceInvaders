using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreLabel, playerScoreLabel;
    [SerializeField] private int playerLives;
    [SerializeField] private GameObject livesImage, gameOverLabel;
    [SerializeField] private Transform livesPanel;
    ActionsController actionsController;
    List<GameObject> livesImages = new List<GameObject>();
    GameController gameController;

    void Awake()
    {
        actionsController = FindAnyObjectByType<ActionsController>();
        gameController = FindAnyObjectByType<GameController>();
    }

    void OnEnable()
    {
        actionsController.gameOver += GameOver;
        actionsController.enemyDestroyed += UpdateScore;
        actionsController.updatePlayerLives += UpdatePlayerLives;
    }

    void OnDisable()
    {
        actionsController.gameOver -= GameOver;
        actionsController.enemyDestroyed -= UpdateScore;
        actionsController.updatePlayerLives -= UpdatePlayerLives;
    }

    private void UpdatePlayerLives(int lives)
    {

        if(livesImages.Count>0)
        {
            GameObject playerdestroyed = livesImages[lives];
            Destroy(playerdestroyed);
        }
    }

    private void UpdateHighScore() 
    {
        highScoreLabel.text = PlayerPrefs.GetInt("score").ToString();
    }


    void Start()
    {
        gameOverLabel.SetActive(false);
        SetupPlayerLives();
        UpdateHighScore();
        playerScoreLabel.text = "0";
    }

    

    void SetupPlayerLives() 
    {
        for (int i = 0; i < playerLives; i++)
        {
            GameObject live = Instantiate(livesImage, livesPanel.position, Quaternion.identity);
            live.transform.SetParent(livesPanel);
            live.transform.localScale = new Vector2(0.6f, 0.6f);
            livesImages.Add(live);
        }
    }

    void UpdateScore() 
    {
        playerScoreLabel.text = gameController.PlayerScore.ToString();
    }

    private void GameOver()
    {
        UpdateHighScore();
        gameOverLabel.SetActive(true);
    }

}
