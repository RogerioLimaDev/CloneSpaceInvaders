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
    public Action<GameData> setHighScore;
    public Action getHighScore;
    public Action<float> setSquadronSpeed;
    public Action boundaryTouched;
    public Action playFireSound;
    public Action playExplosionSound;
    public Action playInvadersKilledSound;
    public Action playUfoSound;
    public Action playShipSound;

    public void PlayShipSound() 
    {
        playShipSound?.Invoke();
    }


    public void PlayFireSound() 
    {
        playFireSound?.Invoke();
    }

    public void PlayExplosionSound() 
    {
        playExplosionSound?.Invoke();
    }

    public void PlayInvadersKilledSound() 
    {
        playInvadersKilledSound?.Invoke();
    }

    public void PlayUfoSound() 
    {
        playUfoSound?.Invoke();
    }
    public void BoundaryTouched() 
    {
        boundaryTouched?.Invoke();
    }

    public void SetSquadronSpeed(float speed) 
    {
        setSquadronSpeed?.Invoke(speed);
    }

    public void SetHighScore(GameData data)
    {
        setHighScore?.Invoke(data);
    }

    public void GetHighScore() 
    {
        getHighScore?.Invoke();
    }

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
