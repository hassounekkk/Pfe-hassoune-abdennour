using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotControllers : MonoBehaviour
{
    Add_Score_db add_Score_Db;
    int level = 4;
    public List<GameObject> players = new List<GameObject>();
    float Timer = 1;
    List<Collider2D> collider2Ds = new List<Collider2D>();
    List<Color> colors = new List<Color>();
    AHH A1;
    public Color[] clr;
    Score score;
    List<List<GameObject>> ayay = new List<List<GameObject>>();
    public GameObject[] kisan;
    List<Color> colors2 = new List<Color>();
    List<bool> checkList = new List<bool>();
    public GameObject secondPlan;
    Collider2D secondPlanCollider;
    float timer_of_finish;
    bool finish;
    public GameObject[] win;
    public GameObject[] True;
    bool saveData;
    public GameObject pl;
    void DistroyIt()
    {
        foreach (GameObject pl in players) Destroy(pl);
        players.Clear();
        collider2Ds.Clear();
        colors.Clear();
        ayay.Clear();
        colors2.Clear();
        checkList.Clear();
    }

    //  bool good;
    // Start is called before the first frame update
    void Start()
    {
        if(level==4)
        {
            score = FindObjectOfType<Score>();
            score.initialiserStars(4);
        }

        DistroyIt();
        Vector2 posi = Vector2.zero;
        int jX = 0;
        for (int i = 0; i < 4; i++) { True[i].SetActive(false); rangeclr(); }
        
            for (int i = 0; i < level; i++)
        {


            players.Add(Instantiate(pl, new Vector3(posi.x++, 0), Quaternion.identity));

            players[i].GetComponent<SpriteRenderer>().color = clr[jX];
            if (jX == 3) jX = 0;
            else
                jX++;
        }
        for (int i = 0; i < kisan.Length; i++)
        {
            kisan[i].GetComponent<SpriteRenderer>().color = clr[i];
            colors2.Add(kisan[i].GetComponent<SpriteRenderer>().color);
            checkList.Add(false);
        }
        secondPlanCollider = secondPlan.GetComponent<Collider2D>();
        for (int i = 0; i < players.Count; i++)
        {
            players[i].SetActive(true);
            collider2Ds.Add(players[i].GetComponent<Collider2D>());
        }

        for (int i = 0; i < players.Count; i++)
        {
            Physics2D.IgnoreCollision(collider2Ds[i], secondPlanCollider);
            for (int j = 0; j < players.Count; j++)
            {

                if (j == i) continue;
                Physics2D.IgnoreCollision(collider2Ds[i], collider2Ds[j]);
            }
        }
        A1 = players[0].GetComponent<AHH>();
        loadColers();


        foreach (Color color in colors)
        {
            ayay.Add(checkifRight(color));
        }
    }

    void rangeclr()
    {
        int x = Random.Range(4, 10);
        int y = Random.Range(0, 4);
        Color aide;
        aide = clr[y];
        clr[y]=clr[x];
        clr[x]=aide;

    }
  
    void check()
    {
        bool good;
        int i = 0;
        foreach (List<GameObject> list in ayay)
        {
            good = true;
            foreach (GameObject gameO in list)
            {
                A1 = gameO.GetComponent<AHH>();
                if (!A1.locked)
                {
                    good = false;
                }
            }
            if (good)
            {
                checkList[i] = true;
            }
            i++;
        }
    }
    void loadColers()
    {
        bool isExiste = false;
        for (int i = 0; i < players.Count; i++)
        {

            if (colors.Contains(players[i].GetComponent<SpriteRenderer>().color))
            {
                isExiste = true;
            }
            else isExiste = false;
            if (!isExiste)
            {
                colors.Add(players[i].GetComponent<SpriteRenderer>().color);
            }
        }
    }

    List<GameObject> checkifRight(Color cl)
    {
        List<GameObject> xxx = new List<GameObject>();
        for (int i = 0; i < players.Count; i++)
        {
            if (cl == players[i].GetComponent<SpriteRenderer>().color)
            {
                xxx.Add(players[i]);
            }
        }
        return xxx;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finish) timer_of_finish += Time.deltaTime;
        check();
        int i = 0;
        foreach (bool bb in checkList)
        {
            if (bb)
            {
                True[i].SetActive(true);

            }
            i++;
        }
        bool EvrybodyLOcked=true;
         foreach (bool bb in checkList)
        {
            if (!bb)
            {
                EvrybodyLOcked = false;

            }
            i++;
        }
        if (EvrybodyLOcked && !finish)
        {
            Timer -= Time.deltaTime; 

        }
        if (Timer <= 0)
        {
            Timer = 1;
            score.AddStar();
            if (level < 12)
            {
                level += 3;
                
                Start();
                
            }
            else
            {
                finish = true;
                
                add_Score_Db = FindObjectOfType<Add_Score_db>();
                if(PlayerPrefs.GetInt("id_user")!=0)
                add_Score_Db.UpdateData(PlayerPrefs.GetInt("id_user") , 13 , 0 , timer_of_finish  );
                for (int j = 0; j < win.Length; j++) win[j].SetActive(true); 
            }
        }
        

    }
    public void back()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);


    }
}
