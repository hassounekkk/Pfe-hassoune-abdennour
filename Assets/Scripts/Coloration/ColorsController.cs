using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorsController : MonoBehaviour
{
    Add_Score_db add_Score_Db;

    public List<GameObject> photosWithoutCl = new List<GameObject>();
    public List<GameObject> photoWithColers = new List<GameObject>();

    List<SpriteRenderer> CurentColer = new List<SpriteRenderer>();
    List<SpriteRenderer> correstedColer = new List<SpriteRenderer>();

    float Timer = 1f;

    Score score;
    int curIndice = 0;
    public Color curColer;
    public GameObject chosenColor;
    SpriteRenderer SpriteRenderers;
    public Color[] colors;
    public Transform positiooon;

    public GameObject[] fin;
    public GameObject fin2;
    public GameObject winning;


    public AudioSource[] colorsVoice;

    bool finish;

    float timer_to_finish;

    /// <summary>

    public Color tryColor1;
    
    //

    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Score>();
        score.initialiserStars(photosWithoutCl.Count);

        foreach(GameObject gameObject in photosWithoutCl)
        {
            gameObject.SetActive(false);
        }
        photosWithoutCl[0].SetActive(true);

        photoWithColers[0] = Instantiate(photoWithColers[0], new Vector2(photosWithoutCl[curIndice].transform.position.x - 7.5f, photosWithoutCl[curIndice].transform.position.y), Quaternion.identity);
        SpriteRenderers = chosenColor.GetComponent<SpriteRenderer>();
        SpriteRenderers.color = curColer;

        

        for(int i=0; i<photoWithColers[0].transform.childCount; i++)
        {
            correstedColer.Add(photoWithColers[0].transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>());
        }
        for (int i = 0; i < photosWithoutCl[0].transform.childCount; i++)
        {
            CurentColer.Add(photosWithoutCl[0].transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>());
        }
    }
    void updateList()
    {
        List<SpriteRenderer> Corr = new List<SpriteRenderer>();
        for (int i = 0; i < photoWithColers[curIndice].transform.childCount; i++)
        {
            Corr.Add(photoWithColers[curIndice].transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>());
        }
        correstedColer = Corr;

        List<SpriteRenderer> Cur = new List<SpriteRenderer>();
        for (int i = 0; i < photosWithoutCl[curIndice].transform.childCount; i++)
        {
            Cur.Add(photosWithoutCl[curIndice].transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>());
        }
        CurentColer = Cur;
    }

    bool  check()
    {
        bool resultat = true;
        for (int i = 0; i < CurentColer.Count; i++)
        {
            if (CurentColer[i].color != correstedColer[i].color)
            {
                resultat = false;
            }
        }
        return resultat;
    }

    public void nextPhoto()
    {
        photosWithoutCl[curIndice].SetActive(false);
        photoWithColers[curIndice].SetActive(false);
        score.AddStar();
        if (curIndice < photosWithoutCl.Count-1)
        {
            curIndice++;
            photoWithColers[curIndice] = Instantiate(photoWithColers[curIndice], new Vector2(photosWithoutCl[curIndice].transform.position.x - 7.5f, photosWithoutCl[curIndice].transform.position.y), Quaternion.identity); ;
            photosWithoutCl[curIndice].SetActive(true);
            updateList();
            
        }
        else if(!finish)
        {
           
                fin2.SetActive(false);
            
            winning.SetActive(true);
            finish = true;
            add_Score_Db = FindObjectOfType<Add_Score_db>();
            if (PlayerPrefs.GetInt("id_user") != 0)
                add_Score_Db.UpdateData(PlayerPrefs.GetInt("id_user"), 16, 0, timer_to_finish);
            
            
        }
    }
     public void ChooseColer(int nbr)
    {
        curColer = colors[nbr];
        colorsVoice[nbr].Play();
    }

    public void changeScene(int n)
    {
        SceneManager.LoadScene(n, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        if(!finish) timer_to_finish += Time.deltaTime;
        SpriteRenderers.color = curColer;

        updateList();

        

        if (check())
        {
            
            for(int i=0; i < fin.Length; i++)
            {
                fin[i].SetActive(true);
            }
            Timer -= Time.deltaTime;
        }
        else
        {
            for (int i = 0; i < fin.Length; i++)
            {
                fin[i].SetActive(false);
            }
        }

        if (Timer <= 0 && !finish)
        {
            nextPhoto();
            Timer = 1;
        }
        
    }
    public void back()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);

    }

}