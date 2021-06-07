using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScean : MonoBehaviour
{
    int id;
    introController cc;
    public int  indice;
    // Start is called before the first frame update
    void Start()
    {
        cc = FindObjectOfType<introController>();
    }

    public void changeScene(int n)
    {
        SceneManager.LoadScene(n, LoadSceneMode.Single);
        PlayerPrefs.SetInt("id_user", id);

    }

    // Update is called once per frame
    void Update()
    {
        id = cc.id;
        
    }
}
