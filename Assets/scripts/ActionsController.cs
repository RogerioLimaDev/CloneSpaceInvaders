using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ActionsController : MonoBehaviour
{
    
    public Action reverseSquadron;
    public Action gameOver;
    public Action enemyDestroyed;
    public Action playerDestroyed;
    public Action<int> fire;
    public Action<int> updatePlayerLives;

    public void UpdatePlayerLives(int lives) 
    {
        updatePlayerLives?.Invoke(lives);
    }

    public void Fire(int projectileSpeed) 
    {
        fire?.Invoke(projectileSpeed);
    }

    public void PlayerDestroyed() 
    {
        playerDestroyed?.Invoke();
    }

    public void EnemyDestroyed() 
    {
        enemyDestroyed?.Invoke();
    }

    public void GameOver() 
    {
        gameOver?.Invoke();
    }

    public void ReverseSquadron() 
    {
        reverseSquadron?.Invoke();
    }
}
