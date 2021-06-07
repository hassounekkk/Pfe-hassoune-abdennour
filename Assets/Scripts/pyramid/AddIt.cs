using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddIt : MonoBehaviour
{
    float timer_of_finish=0;
    Add_Score_db add_Score_Db;
    public GameObject[] scean;
    public GameObject win;
    // Start is called before the first frame update
    int level = 0;
    public  float Timer=0.5f;
    public int nbrI = 0;
    public GameObject[] items;
    public  bool isTrue=false;
    List <Vector2> placeInitiale = new List<Vector2>();
    public  List<GameObject> CurItems = new List<GameObject>();
    List<AAAAA> a1 = new List<AAAAA>();
    bool evrythingLocked=false;
    Score score;
    bool restart = false;
    float TimerTorestart=1;
    public GameObject MonikoVrai;
    public GameObject Monikofalse;
    bool finish;
    int njom;
    public GameObject[] njom_sofar;
    void Start()
    {
        
        if (level < 3)
        {
            score = FindObjectOfType<Score>();
            score.initialiserStars(3);
            for (int i = 0; i < items.Length; i++) items[i].SetActive(false);
            CurItems.Clear();
            placeInitiale.Clear();
            a1.Clear();
            if (level == 0) treeItms();
            if (level == 1) fiveItems();
            if (level == 2) for (int i = 0; i < items.Length; i++) CurItems.Add(items[i]);
            for (int i = 0; i < CurItems.Count; i++)
            {
                placeInitiale.Add(CurItems[i].transform.position);

                a1.Add(CurItems[i].GetComponent<AAAAA>());
            }
            foreach (GameObject gm in CurItems)
            {
                gm.SetActive(true);
            }
        }
        else {
            for (int i = 0; i < scean.Length; i++) scean[i].SetActive(false);
            win.SetActive(true);
            finish = true;
            add_Score_Db = FindObjectOfType<Add_Score_db>();

            if (timer_of_finish <= 30)
            {
                njom = 3;
                for (int i = 0; i < njom_sofar.Length; i++) njom_sofar[i].SetActive(true);
            }
            else if (timer_of_finish <= 60 && timer_of_finish >= 30)
            {
                njom = 2;
                njom_sofar[0].SetActive(true);
                njom_sofar[1].SetActive(true);
            }
            else 
            { 
                njom = 1;
                njom_sofar[0].SetActive(true);
            }
            if(PlayerPrefs.GetInt("id_user")!=0)
                add_Score_Db.UpdateData( PlayerPrefs.GetInt("id_user")   ,  11  ,  njom  , timer_of_finish);
        }

        

    }
    void treeItms()
    {

        List<int> x = Random3Num(items.Length);
        foreach (int n in x)
        {
            CurItems.Add(items[n]);
        }
        
    }
    void fiveItems()
    {
        List<int> x = Random3Num(5);
        int a = Random.Range(5, items.Length);
        x.Add(a);
        a = Random.Range(5, items.Length);
        while(a==x[3]) a = Random.Range(5, items.Length);
        x.Add(a);
        x.Sort();
        foreach (int n in x)
        {
            CurItems.Add(items[n]);
        }
     
    }
    List<int> Random3Num(int n)
    {
        List<int> A = new List<int>();
        A.Add(Random.Range(0,n));
        int x = Random.Range(0, 7);
        while(A[0]==x) x = Random.Range(0, n);
        A.Add(x);
        x = Random.Range(0, 7);
        while (A[0] == x || x==A[1] ) x = Random.Range(0, n);
        A.Add(x);
        A.Sort();
        return A ;
    }
    public void Restart()
    {
        for (int i = 0; i < CurItems.Count; i++)
        {
            CurItems[i].transform.position = placeInitiale[i];
            a1[i].IsLocked = false;
        }
        nbrI = 0;
        isTrue = false;
        for (int i = 0; i < a1.Count; i++)
        {
           a1[i].IsLocked= false;
        }
    }  
    void check()
    {
        isTrue = true;
        for (int i = 0; i < CurItems.Count-1; i++)
        {
            if (CurItems[i].transform.position.y > CurItems[i + 1].transform.position.y) isTrue = false;

        }
    }
    void locked()
    {
        evrythingLocked = true;
        for (int i =0;i< a1.Count; i++)
        {
            if (!a1[i].IsLocked) evrythingLocked = false;
        }
    }
    void Update()
    {

        //Debug.Log( PlayerPrefs.GetInt("id_user") );

        locked();
        if (evrythingLocked) check();
        if (isTrue) { Timer -= Time.deltaTime; MonikoVrai.SetActive(true); }
        if (isTrue && Timer <= 0  )
        {
            if (level != 3)
            {
                Timer = 0.5f;
                Restart();
                level++;
                Start();
                score.AddStar();
                MonikoVrai.SetActive(false);
            }
            else finish = true;
        }
        if (!isTrue && nbrI == CurItems.Count) { TimerTorestart -= Time.deltaTime; Monikofalse.SetActive(true); }
        if (TimerTorestart <= 0)
        {
            TimerTorestart = 1;
            Monikofalse.SetActive(false);
            Restart();        
        }
        if (!finish) timer_of_finish+=Time.deltaTime;   
    }
    public void back()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);    
    }
    
}
