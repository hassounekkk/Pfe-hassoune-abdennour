using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class introController : MonoBehaviour
{
    public int id;
    public GameObject Butons;
    public GameObject ButonsTasjil;
    public GameObject ButonsKhawi;
    public GameObject Next;
    public GameObject back;
    public Text ttt;

    public GameObject sceanLogOut;

    User user = new User();
    [System.Serializable]
    public class User
    {
        public int id;
        public string name;
        public string password;
        public string kid_name;
    }

    public void logingOut()
    {
        sceanLogOut.SetActive(true);
    }

    public void logOutNo()
    {
        sceanLogOut.SetActive(false);
    }

    public void logOutYea()
    {
        PlayerPrefs.SetString("name", null);
        PlayerPrefs.SetInt("id_user", 0);
        Start();
    }

    // Start is called before the first frame update
    void Start()
    {
        sceanLogOut.SetActive(false);
        string name;
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("name")))
        {
            name = "";
            ButonsTasjil.SetActive(true);
            ButonsKhawi.SetActive(false);
        }
        else
        {
            ButonsKhawi.SetActive(true);
            ButonsTasjil.SetActive(false);
            name = PlayerPrefs.GetString("name");
            get_Id(name);
        }
        
        ttt.text = name;
       
    }

    IEnumerator GetID(string uri)
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
            user = JsonUtility.FromJson<User>(aaa);
            id = user.id;
        }
    }

    void get_Id(string name)
    {
        StartCoroutine(GetID("http://127.0.0.1:5000/get/" + name));
    }

    public void NextPage()
    {
        for(int i =0; i < 6; i++)
        {
            Butons.transform.GetChild(i).gameObject.SetActive(false);
            Butons.transform.GetChild(11-i).gameObject.SetActive(true);
            Next.SetActive(false);
            back.SetActive(true);
        }

    }    
    public void BackPage()
    {
        for(int i =0; i < 6; i++)
        {
            Butons.transform.GetChild(i).gameObject.SetActive(true);
            Butons.transform.GetChild(11-i).gameObject.SetActive(false);
            Next.SetActive(true);
            back.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
