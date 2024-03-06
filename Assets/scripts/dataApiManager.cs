using UnityEngine;
using System.Net;
using System.IO;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

public class dataApiManager : MonoBehaviour
{
    [SerializeField] private Credentials credentials;
    Joke currentJoke;
    ActionsController actionsController;

    void Awake()
    {
        actionsController = FindAnyObjectByType<ActionsController>();
    }

    void OnEnable()
    {
        actionsController.setHighScore += SaveToPlayerPrefs;
        actionsController.getHighScore += GetFromPlayerPrefs;
    }

    void OnDisable()
    {
        actionsController.setHighScore -= SaveToPlayerPrefs;
        actionsController.getHighScore -= GetFromPlayerPrefs;
    }

    private void SaveToPlayerPrefs(GameData data) 
    {
        PlayerPrefs.SetString("user", data.players[0]);
        PlayerPrefs.SetInt("score", data.scores[0]);
        Debug.Log($"Data saved to PlayePrefs: User {data.players[0]} Score: {data.scores[0]} ");
    }

    private void GetFromPlayerPrefs() 
    {
        //Provisorio//
        //TODO : recuperar dados do database
    }

    [ContextMenu ("GetRequest")]
    private async void GetRequest() 
    {
        var url = credentials.getUrl;
        var www =  UnityWebRequest.Get(url);
        www.SetRequestHeader("Content-Type","application/json");
        var operation = www.SendWebRequest();
        while(!operation.isDone)
            await Task.Yield();

            var jsonResponse = www.downloadHandler.text;

        try
        {
            var result = JsonUtility.FromJson<Joke>(jsonResponse);
            Debug.Log($"get request successful <color=yellow><b>{result.value}</b></color>");

        }
        catch(Exception ex)
        {

            Debug.Log($"{this} could not parse {jsonResponse}, {ex.Message}");
        }
    }

    [ContextMenu ("PostRequest") ]
    public void MakePostRequest() 
    {
        GameData gd = new GameData();
        gd.players =  new List<string>();
        gd.scores = new List<int>();
        gd.players.Add("catatau");
        gd.scores.Add(1234);

        PostRequest(gd);

    }


    private async Task PostRequest(GameData gameData) 
    {
        var url = credentials.postUrl;
        string json = JsonUtility.ToJson(gameData);
        var www = UnityWebRequest.PostWwwForm(url,json);
        var operation = www.SendWebRequest();

        while(!operation.isDone)
            await Task.Yield();

        if(www.result == UnityWebRequest.Result.Success)
        {
            var response = www.downloadHandler.text;
            Debug.Log($"Post operation successful {response}");
        }else
        {
            Debug.Log($"post error: {www.error}");
        }
    }

    [ContextMenu("ApiCall")]
    private void ApiCall() 
    {
        HttpWebRequest request = WebRequest.Create(credentials.key) as HttpWebRequest;
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;

        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        currentJoke = JsonUtility.FromJson<Joke>(json);
        Debug.Log(currentJoke.value);
    }
    
}
