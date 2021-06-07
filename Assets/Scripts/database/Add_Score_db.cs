using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Add_Score_db : MonoBehaviour
{
    string game_name;
    public void UpdateData(int id_user, int game_id, int score, float time)
    {
        string url = "http://127.0.0.1:5000/score/update/" + id_user + "/" + game_id + "/" + score + "/" + time;
        StartCoroutine(GetRequest(url));

    }

    void get_game_id()
    {

        StartCoroutine(GetRequest("http://127.0.0.1:5000/game/get/" + game_name));
    }

    IEnumerator GetRequest(string uri)
    {

        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();
        string hhhh = "absn";
        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            String aaa = uwr.downloadHandler.text;
            Debug.Log(aaa);
            //Game gs = JsonUtility.FromJson<Game>(aaa);
            //game.game_id = gs.game_id;
        }
    }

    [System.Serializable]
    public class Game
    {
        public int game_id;
        public string game_name;
    }

}
