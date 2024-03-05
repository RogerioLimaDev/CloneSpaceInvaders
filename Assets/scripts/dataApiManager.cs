using UnityEngine;
using System.Net;
using System.IO;

public class dataApiManager : MonoBehaviour
{
    [SerializeField] private Credentials credentials;
    Joke currentJoke;
    ActionsController actionsController;

    void Awake()
    {
        actionsController = FindAnyObjectByType<ActionsController>();
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
