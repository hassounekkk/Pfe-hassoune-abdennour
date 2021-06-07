using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectController : MonoBehaviour
{
    Add_Score_db add_Score_Db;
    bool finish;
    float timer_of_finish = 0;
    float timer=1.5F;
    float timerforRandom=3F;
    bool random;
    
    public GameObject[] photoKamla;
     List<GameObject> photos = new List<GameObject>();
     List<MoveUpAndDown> M = new List<MoveUpAndDown>();
    Vector2[] place_Initial = new Vector2[6];
    Score score;



    public List<GameObject> RightPosition;
  public  int indicePhoto=0;

    bool riiiiiight;

public    GameObject Wiii;
public    GameObject wiiiA;
   public void InitialisePosition()
    {
        RightPosition.Clear();
        photos.Clear();
        M.Clear();
        for (int i = 0; i < photoKamla[indicePhoto].transform.childCount; i++) RightPosition.Add(photoKamla[indicePhoto].transform.GetChild(i).gameObject);
        for (int i = 0; i < photoKamla[indicePhoto].transform.childCount; i++)
        {
            photos.Add(photoKamla[indicePhoto].transform.GetChild(i).gameObject);
            M.Add(photoKamla[indicePhoto].transform.GetChild(i).GetComponent<MoveUpAndDown>());
        }
        
    }
    public void NextPhoto()
    {
        if (indicePhoto < photoKamla.Length - 1)
        {
            photoKamla[indicePhoto].SetActive(false);
            indicePhoto++;
            photoKamla[indicePhoto].SetActive(true);
            
            InitialisePosition();
            score.AddStar();

        }
        else
        {
            finish = true;
            wiiiA.SetActive(true);
            photoKamla[indicePhoto].SetActive(false);
            add_Score_Db = FindObjectOfType<Add_Score_db>();
            if (PlayerPrefs.GetInt("id_user") != 0)
                add_Score_Db.UpdateData(PlayerPrefs.GetInt("id_user"), 12, 0, timer_of_finish);
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Score>();
        InitialisePosition();

        for (int i = 0; i < photoKamla.Length; i++) photoKamla[i].SetActive(false);
        photoKamla[0].SetActive(true);

        updatePosition();

        random = true;
        score.initialiserStars(photoKamla.Length - 1);
    }

    public void rondomObjects()
    {
        updatePosition();
        int t = Random.Range(0, 6);
        int k = Random.Range(0, 6);
        while (t == k)
        {
            k = Random.Range(0, 6);
        }
        photos[t].transform.position = place_Initial[k];
        photos[k].transform.position = place_Initial[t];
        GameObject T;
        T = photos[t];
        photos[t] = photos[k];
        photos[k] = T;
        updatePosition();
        for (int j = 0; j < M.Count; j++)
        {
            M[j].UpdatePosition();
        }
    }

    public void updatePosition()
    {
        for (int i = 0; i < photos.Count; i++)
        {
            place_Initial[i] = photos[i].transform.position;
        }
    }

    public void change(int i, bool A)
    {
        if (A)
        {

            photos[i + 1].transform.position = place_Initial[i];
            photos[i].transform.position = place_Initial[i + 1];
        }
        else
        {
            photos[i - 1].transform.position = place_Initial[i];
            photos[i].transform.position = place_Initial[i - 1];

        }
        changeGameO(i, A);
        updatePosition();
        for(int j =0; j<M.Count; j++)
        {
            M[j].UpdatePosition();
        }
    }
    void changeGameO(int i, bool A)
    {
        GameObject T;
        if (A)
        {
            T = photos[i + 1];
            photos[i + 1] = photos[i];
            photos[i] = T;
        }
        else
        {
            T = photos[i - 1];
            photos[i - 1] = photos[i];
            photos[i] = T;

        }
    }
    private void Update()
    {
        riiiiiight = true;
        check();
        if (riiiiiight && random==false)
        {
            Wiii.SetActive(true);
            timer -= Time.deltaTime;

        }
        if (timer <= 0)
        {
            timer = 1.5f;
            NextPhoto();
            Wiii.SetActive(false);
            random = true;
        }
        if (random)
        {
            timerforRandom -= Time.deltaTime;
        }
        if (timerforRandom <= 0)
        {
            random = false;
            timerforRandom = 3f;
            rondomObjects();
          
        }

        void check()
        {
            int i = 0;
            foreach (GameObject child in RightPosition)
            {
                if (child.transform.position != photos[i].transform.position) riiiiiight = false;
                i++;
            }
        }
        if(!finish)
        timer_of_finish += Time.deltaTime;
    }
    public void back()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);


    }
}
