using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Log_in : MonoBehaviour
{

    int id;
    public InputField Name;
    public InputField password;
    public GameObject xxx;
    List<String> all = new List<string>();
    bool CanLog;
    User user = new User();
    bool locked;
   public float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GetData()
    {
        StartCoroutine(GetRequest("http://127.0.0.1:5000/get/"+Name.text));
    }

    public void back()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
             xxx.SetActive(true);
        }
        else
        {

            String aaa = uwr.downloadHandler.text;
            if (aaa == "None")  xxx.SetActive(true); 
            else
            {
                user = JsonUtility.FromJson<User>(aaa);
                CanLog = true;
            }
        }
    }

    void check()
    {
        if (user.password == password.text)
        {
            xxx.SetActive(false);
            PlayerPrefs.SetString("name", Name.text);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        else xxx.SetActive(true);
    }

    private void Update()
    {
        if (CanLog) timer -= Time.deltaTime;
        if(timer<=0)
        {
            timer = 1;
            CanLog = false;
            check();
        }
    }



    [Serializable]
    public class User
    {
        public int id;
        public string name;
        public string password;
        public string kid_name;
    }

}
