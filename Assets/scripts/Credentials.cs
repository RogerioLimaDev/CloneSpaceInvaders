using UnityEngine;

[CreateAssetMenu(fileName = "Credentials", menuName = "Credentials", order = 0)]
public class Credentials : ScriptableObject 
{
    public string Service;
    public string key;
    public string secret;
    public string getUrl;
    public string postUrl;
    public string createUrl;
    public string deleteUrl;
}