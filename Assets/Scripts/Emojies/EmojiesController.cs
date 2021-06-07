using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmojiesController : MonoBehaviour
{
    bool finish;
    float timer_to_finish;
    Add_Score_db add_Score_Db;

    public List<GameObject>  Angry = new List<GameObject>();
    public List<GameObject>  sad = new List<GameObject>();
    public List<GameObject>  happy = new List<GameObject>();
    public GameObject Place;
   public int CurIndice;
    Vector2 place;
    int  mood;
    bool right;
    public GameObject[] emojieis;
    int lastClick;
   public List<GameObject> ListOfPhotos = new List<GameObject>();
    Vector2 ScalOfIt;
    List<Vector2> placeInitial = new List<Vector2>();
    float timer = 2;
    int level;
    // Start is called before the first frame update

    private void Awake()
    {
        for (int i = 0; i < emojieis.Length; i++) placeInitial.Add(emojieis[i].transform.position);
          ScalOfIt = emojieis[0].transform.localScale;
        place = Place.transform.position;
        InitialiserList();
        for (int i = 0; i < 4; i++) randomPositions();
    }

    void Start()
    {

        for (int i = 0; i < emojieis.Length; i++)
        {
            emojieis[i].transform.localScale = ScalOfIt;
            emojieis[i].transform.position = placeInitial[i];
        }
            updateMode();
        ListOfPhotos[CurIndice] = Instantiate(ListOfPhotos[CurIndice] , place , Quaternion.identity); 


    }

    void updateMode()
    {
        if (sad.Contains(ListOfPhotos[CurIndice]))
        {
            mood = 0;
        }
        if (happy.Contains(ListOfPhotos[CurIndice]))
        {
            mood = 1;
        }
        if (Angry.Contains(ListOfPhotos[CurIndice]))
        {
            mood = 2;
        }
    }

    public void randomPositions()
    {
        GameObject aide;
        int x = Random.Range(0,ListOfPhotos.Count/2);
        int y = Random.Range(ListOfPhotos.Count/2, ListOfPhotos.Count);
        aide = ListOfPhotos[x];
        ListOfPhotos[x] = ListOfPhotos[y];
        ListOfPhotos[y] = aide;
    }

    public void check(int a)
    {
        lastClick = a;
        if (a == mood) {
            emojieis[a].transform.position = new Vector2(0,-3);
            emojieis[a].LeanScale(new Vector2(0.5f,0.5f), 1);
            right = true;
           
        }
        else emojieis[a].LeanScale(new Vector2(0.05f, 0.05f), 1); ;
    }

    void InitialiserList()
    {
        for (int i = 0; i < Angry.Count; i++) {
            ListOfPhotos.Add( Angry[i] );
                
        }for (int i = 0; i < sad.Count; i++) {
            ListOfPhotos.Add( sad[i] );
                }
        for (int i = 0; i < happy.Count; i++) {
            ListOfPhotos.Add( happy[i] );
                }
    }

    // Update is called once per frame
    void Update()
    {
        if (!finish) timer_to_finish += Time.deltaTime;

        if (right) timer -= Time.deltaTime;

        if(timer<=0){
            if (level < ListOfPhotos.Count-1)
            {
                level++;
                timer = 2;
                right = false;
                ListOfPhotos[CurIndice].SetActive(false);
                CurIndice++;
                Start();
            }
            else
            {
                timer = 2;
                finish = true;
            }
            if (finish)
            {
                add_Score_Db = FindObjectOfType<Add_Score_db>();
                if (PlayerPrefs.GetInt("id_user") != 0)
                    add_Score_Db.UpdateData(PlayerPrefs.GetInt("id_user"), 20, 0, timer_to_finish);
                finish = false;
            }
            
        }
        
    }
    public void back()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);

    }

}
