using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTableController : MonoBehaviour
{
    Add_Score_db add_Score_Db;
    float Timer_to_finish;
    bool finish;
    int level = 0;
    Score score;
    int NbrItems;
    float Timer2 = 1;
     float Timer = 0.5f ;
    bool isRight;
    bool isFalse;
    public List<GameObject> posi = new List<GameObject>();
    public List<Sprite> A = new List<Sprite>();
    public List<Texture> Numbers = new List<Texture>();
     
    public GameObject[] Buttons;

   public GameObject monikoVrai;
   public GameObject monikoFalse;
    // Start is called before the first frame update
    void Start()
    {

        if (level < 10 && !finish)
        {
            if (level == 0)
            {
                score = FindObjectOfType<Score>();
                score.initialiserStars(10);
            }
            monikoFalse.SetActive(false);
            monikoFalse.SetActive(false);


            for (int i = 0; i < posi.Count; i++)
            {
                posi[i].GetComponent<SpriteRenderer>().sprite = null;
            }

            for (int i = 0; i < Buttons.Length; i++) Buttons[i].SetActive(true);
            NbrItems = Random.Range(1, posi.Count);
            int x = Random.Range(0, A.Count);
            for (int i = 0; i < NbrItems; i++)
            {
                posi[i].GetComponent<SpriteRenderer>().sprite = A[x];
            }
            displayit();
            inisialiserButtons();
            level++;
        }
        else if(!finish) {
            finish = true;
            add_Score_Db = FindObjectOfType<Add_Score_db>();
            if (PlayerPrefs.GetInt("id_user") != 0)
                add_Score_Db.UpdateData(PlayerPrefs.GetInt("id_user"), 15, 0, Timer_to_finish);
        }
        
    }

    void displayit()
    {
        Vector2[] Aa = new Vector2[posi.Count];
        for (int i = 0; i < NbrItems; i++)
        {
            Aa[i] = posi[i].transform.localScale;
            posi[i].transform.localScale = new Vector2(0,0) ;

        }
        for (int i = 0; i < NbrItems; i++)
        {
            posi[i].LeanScale(Aa[i], 0.5f);

        }
    }

    void inisialiserButtons()
    {
        Buttons[0].GetComponent<RawImage>().texture = Numbers[NbrItems - 1];
        int x, y;
        x = Random.Range(1, 9);
            while (x == NbrItems - 1) x = Random.Range(1, 9);
        y = Random.Range(1,9);
        while (y == NbrItems - 1 || x == y) y = Random.Range(1, 9);
        Buttons[1].GetComponent<RawImage>().texture = Numbers[x];
        Buttons[2].GetComponent<RawImage>().texture = Numbers[y];
        for (int i= 0; i < 3; i++)
        {
            RandomPosi();
        }
    }
    void RandomPosi()
    {
        int x = Random.Range(1, 3);
        Vector2 aide = Buttons[0].transform.position;
        Buttons[0].transform.position = Buttons[x].transform.position;
        Buttons[x].transform.position = aide;


    }

    public void rightChose(int indice)
    {
        if (indice == 0)
            isRight = true;
        else
        {
            Buttons[indice].SetActive(false);
            isFalse = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!finish) Timer_to_finish += Time.deltaTime;

        if (isRight)
        {
            Timer -= Time.deltaTime;
            monikoVrai.SetActive(true);
            
        }

        if(Timer <= 0)
        {
            monikoVrai.SetActive(false);
            Timer = 0.5f;
            score.AddStar();
            Start();
            isRight = false;

        }
        if (isFalse)
        {
            monikoFalse.SetActive(true);
            Timer2 -= Time.deltaTime;
        }


        if (Timer2 <= 0)
        {
            Timer2 = 1f;
            monikoFalse.SetActive(false);
            isFalse = false;
        }
    }
    public void back()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);


    }
}
