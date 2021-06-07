using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlGame : MonoBehaviour
{
    Add_Score_db add_Score_Db;
    public GameObject[] Object;
    public GameObject[] OnPut;
    public Transform[] positions;
    Score score;
    public GameObject Winning;
    public GameObject Gamex;
    public int Indice =0 ;
     int t;
    int k, j;

    float timer_to_finish;
    bool finish;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Score>();
        score.initialiserStars(Object.Length);
        reIanisialise();
    }

    void reIanisialise()
    {
        

        for (int i = 0; i < Object.Length; i++)
        {
            Object[i].SetActive(false);
        }
        Object[Indice].SetActive(true);
        t = Random.Range(0, 3);
        OnPut[Indice].SetActive(true); OnPut[Indice].transform.position = positions[t].position;
        
         k = Random.Range(0, OnPut.Length);
        while (k == Indice)
        {
            k = Random.Range(0, OnPut.Length);
        }
         j = Random.Range(0, OnPut.Length);
        while (j == Indice || j == k)
        {
            j = Random.Range(0, OnPut.Length);
        }
        if (t == 0)
        {
            OnPut[k].SetActive(true); OnPut[k].transform.position = positions[1].position;
            OnPut[j].SetActive(true); OnPut[j].transform.position = positions[2].position;

        }
        else if (t == 1)
        {
            OnPut[k].SetActive(true); OnPut[k].transform.position = positions[2].position;
            OnPut[j].SetActive(true); OnPut[j].transform.position = positions[0].position;
        }
        else
        {
            OnPut[k].SetActive(true); OnPut[k].transform.position = positions[0].position;
            OnPut[j].SetActive(true); OnPut[j].transform.position = positions[1].position;
        }
    }

    public void LoadNextOne()
    {


        OnPut[Indice].SetActive(false);
        OnPut[k].SetActive(false);
        OnPut[j].SetActive(false);
        score.AddStar();
        if (Indice < Object.Length - 1)
        {
            Indice++;
            reIanisialise();
            for (int i = 0; i < Object.Length; i++)
            {
                Object[i].SetActive(false);
            }
            Object[Indice].SetActive(true);
        }
        else
        {
            Winning.SetActive(true);
            Gamex.SetActive(false);
            finish = true;
            add_Score_Db = FindObjectOfType<Add_Score_db>();
            if (PlayerPrefs.GetInt("id_user") != 0)
                add_Score_Db.UpdateData(PlayerPrefs.GetInt("id_user"), 17, 0, timer_to_finish);

        }
    }
    public void changeScene(int n)
    {
        SceneManager.LoadScene(n, LoadSceneMode.Single);
    }

    public Vector3 Goal()
    {
        return positions[t].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if(!finish) timer_to_finish += Time.deltaTime;
    }

}
