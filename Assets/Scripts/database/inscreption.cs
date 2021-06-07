using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class inscreption : MonoBehaviour
{
    public InputField Name;
    public InputField Kid_name;
    public InputField password;
    public InputField password_pw;
    public GameObject erreur_txt;
    private bool isLoged;
   public float timerToGo = 2;
    private bool CanLog;

    User user = new User();

    bool create=false;
    public float timer = 2;

    private void Start()
    {
       
    }

    void check_Info()
    {
        if (Name.text == "" || password.text == "" || password_pw.text == "")
        {
            CanLog = false;
        }
        if (password.text != password_pw.text) CanLog = false;
    }

    public void Se_connecter()
    {
        CanLog = true;
        check_Info();
        if (CanLog)
        {
            erreur_txt.SetActive(false);
            

            user.name = Name.text;
            user.kid_name = Kid_name.text;
            user.password = password.text;

            string json = JsonUtility.ToJson(user);
            StartCoroutine(PostRequest("http://127.0.0.1:5000/post", json));
        }
        else erreur_txt.SetActive(true);
    }

    
    // Update is called once per frame

    [Serializable]
    public class User
    {
        public int id;
        public string name;
        public string password;
        public string kid_name;
    }

    public IEnumerator PostRequest(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            if(uwr.downloadHandler.text== "Gooooooooood")
            {


                create = true;

            }
        }
        
    }

    void get_Id()
    {
        StartCoroutine(GetRequest("http://127.0.0.1:5000/get/"+user.name));
        isLoged = true;
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

            user = JsonUtility.FromJson<User>(aaa);

            for (int i = 11; i <= 20; i++)
            {
                string url = "http://127.0.0.1:5000/score/" + user.id + "/" + i;
                UnityWebRequest query = UnityWebRequest.Get(url);
                yield return query.SendWebRequest();
            }
            
        }
    }

    public void back()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    void Update()
    {
        if (create) timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 2;
            create = false;
            get_Id();
        }
        if (isLoged) timerToGo -= Time.deltaTime;
        if (timerToGo <= 0)
        {
            PlayerPrefs.SetString("name", Name.text);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            timerToGo = 3;
            isLoged = false;
        }
    }


    public void SeConnecter()
    {
        SceneManager.LoadScene(12, LoadSceneMode.Single);
    }

}

