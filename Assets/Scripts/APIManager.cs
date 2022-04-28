using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APIManager : MonoBehaviour
{
    [SerializeField]
    private string url;

    [SerializeField]
    private string key = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiJkZTg2NzI2MC1hOTRjLTAxM2EtY2I3ZS0wMTM2YWI5NGY3N2IiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjUxMTY5NjI2LCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6Ii0xMGQyOGM5NC1kMGVjLTQyNDAtYTY0MC1kYTMxMmVhNjFmYzUifQ.wy70kMkfJEaiGTewqJHfzA6l09PEgYgTuAxfGsPi-AI";

    private string msg;

    static Tournament tournamentInfo;

    public static System.Action onGetTournaments;

    private void Start() {
        Request();
    }

    public void Request()
    {
        StartCoroutine(GetFromAPI());
        
    }

    private IEnumerator GetFromAPI()
    {
       using(UnityWebRequest request = UnityWebRequest.Get(url))
       {
           request.SetRequestHeader("accept","application/vnd.api+json");
           request.SetRequestHeader("Authorization", "Bearer " + key);

           request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
           
           yield return request.SendWebRequest();
           if(request.result == UnityWebRequest.Result.ConnectionError) msg = request.error;
           else if (request.result == UnityWebRequest.Result.Success)
           {
               msg = request.downloadHandler.text;
               tournamentInfo = JsonUtility.FromJson<Tournament>(msg);
               onGetTournaments?.Invoke();
           }

       }
    }

    public static Tournament GetTournamentInfo()
    {
        return tournamentInfo;
    }
}
