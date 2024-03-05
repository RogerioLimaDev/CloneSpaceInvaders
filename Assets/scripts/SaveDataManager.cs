using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataManager Instance;
    private int finalScore;
    private int highScore;
    private string currentPlayer;
    private GameData gameData;
    private FileStream file;


    void Awake()
    {
        if(Instance == this)
        {
            DontDestroyOnLoad(this.gameObject);

        }else
        {
            Destroy(this.gameObject);
        }
    }

    public void Save()
    {
        BinaryFormatter bf =  new BinaryFormatter();

        if(File.Exists(Application.persistentDataPath + "/highScores.dat"))
        {
            file = File.Open(Application.persistentDataPath + "/highScores.dat", FileMode.Open);
            gameData =  bf.Deserialize(file) as GameData;
            gameData.players.Add(currentPlayer);
            gameData.scores.Add(finalScore);

        }else
        {
            file = File.Create(Application.persistentDataPath + "/highScores.dat");
            gameData = new GameData();
            gameData.players.Add(currentPlayer);
            gameData.scores.Add(finalScore);
        }

        bf.Serialize(file, gameData);
        file.Close();
    }

    public int HighScore()
    {
        BinaryFormatter bf =  new BinaryFormatter();

        if(File.Exists(Application.persistentDataPath + "/highScores.dat"))
        {
            file = File.Open(Application.persistentDataPath + "/highScores.dat", FileMode.Open);
            gameData =  bf.Deserialize(file) as GameData;
        }
        else
        {
            return 0;
        }
        List<string> lastPlayers = gameData.players;
        List<int> lastScores = gameData.scores;
        lastScores.Sort();
        highScore = lastScores[0];
        file.Close();
        return highScore;
    }
}
