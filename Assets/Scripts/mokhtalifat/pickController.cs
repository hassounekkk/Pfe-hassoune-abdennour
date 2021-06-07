using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pickController : MonoBehaviour
{
    float timer_to_finish;
    bool finish;
    Add_Score_db add_Score_Db;


    public Texture[] txt;
    public List<GameObject> butn = new List<GameObject>();

   public float timer = 0.7f;
    public float timer2 = 0.7f;
    int level = 0;
    bool isRight;
    bool isFalse;
    bool display;
    public GameObject monikoVrai;
    public GameObject monikoFalse;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        if (level < 10)
        {
            score = FindObjectOfType<Score>();
            score.initialiserStars(10);

            monikoFalse.SetActive(false);
            monikoVrai.SetActive(false);

            int falseTxt = Random.Range(0, txt.Length);
            int indiceTree = Random.Range(0, txt.Length);
            while (falseTxt == indiceTree) indiceTree = Random.Range(0, txt.Length);
            butn[0].GetComponent<RawImage>().texture = txt[falseTxt];
            butn[1].GetComponent<RawImage>().texture = txt[indiceTree];
            butn[2].GetComponent<RawImage>().texture = txt[indiceTree];
            butn[3].GetComponent<RawImage>().texture = txt[indiceTree];

            randomIt();

            foreach (GameObject btn in butn) btn.transform.localScale = Vector2.zero;
            foreach (GameObject btn in butn) btn.LeanScale(new Vector2(2, 2), 1);
        }

        if (level == 10)
        {
            finish = true;
            add_Score_Db = FindObjectOfType<Add_Score_db>();
            add_Score_Db.UpdateData(PlayerPrefs.GetInt("id_user"), 18, 0, timer_to_finish);
        }
    }

    private void randomIt()
    {
        int n = Random.Range(1, 4);
        Vector2 aide = butn[0].transform.position;
        butn[0].transform.position = butn[n].transform.position;
        butn[n].transform.position = aide;
    }

   public void choosen( int n)
    {
        if (n == 0) { display = false; isRight = true; indice = 0; }
        else isFalse = true;

    }

    void DisplayItems(int n)
    {
        if (n < 4)
            butn[n].LeanScale(new Vector2(2, 2), 1);
        else
        {
            display = true;
            indice = 0;
        }

    }
    int indice = 0;
    // Update is called once per frame
    void Update()
    {
        if (!finish) timer_to_finish += Time.deltaTime;
   

        if (isRight && level<10) { timer -= Time.deltaTime; monikoVrai.SetActive(true); }

        

        if (timer <= 0)
        {
            score.AddStar();
            level++;
            timer = 1;
            isRight = false;
            Start();
        }


        if (isFalse) { timer2 -= Time.deltaTime; monikoFalse.SetActive(true); }
        if (timer2 <= 0)
        {
            timer2= 1;
            isFalse = false;
            monikoFalse.SetActive(false);
        }

    }
    public void back()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);

    }

}
