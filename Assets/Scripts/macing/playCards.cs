using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playCards : MonoBehaviour
{
    float timer_to_finish;

    public bool finish;

    public GameObject nextButton;

    public float timer1 = 0.3F;

    public float timer2 = 0.5f;

    bool add_data;

    Add_Score_db add_Score_Db;

    bool clicked;

    int nbrFaces=0;

    bool next=false;

    public int FirstClicked;
    public int secondClicked;

    public GameObject[] winScean;


    public int nbrPhotos =2;
    public GameObject[] places;
    
    Score score;

    public List<GameObject> photoFace = new List<GameObject>();
    List<GameObject> backPhoto = new List<GameObject>();
    List<GameObject> truue = new List<GameObject>();
    public int nbrItemsTrue=0;

    //
    public Texture[] Txt;
    public void back()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);


    }
    void Inisialiser()
    {
        int i = 0;
            if (nbrPhotos == 2)
            {

                places[0].SetActive(true);
            for (int j = 4; j < places[0].transform.childCount-2; j++)
            {
                backPhoto.Add(item: places[0].transform.GetChild(j-4).gameObject);
                photoFace.Add(item: places[0].transform.GetChild(j).gameObject);
                photoFace[i].transform.localScale = new Vector2(0, 0);
                i++;
            } 
            truue.Add(item: places[0].transform.GetChild(places[0].transform.childCount - 2).gameObject);
            truue.Add(item: places[0].transform.GetChild(places[0].transform.childCount - 1).gameObject);
        }
            else if (nbrPhotos == 4)
            {
                places[1].SetActive(true);
                for (int j = 8; j < places[1].transform.childCount-4; j++)
                {
                backPhoto.Add(item: places[1].transform.GetChild(j - 8).gameObject);

                photoFace.Add(item: places[1].transform.GetChild(j).gameObject);
                    photoFace[i].transform.localScale = new Vector2(0, 0);
                    i++;
                }
            for (int k = 4; k > 0; k--)
            {
                truue.Add(item: places[1].transform.GetChild(places[1].transform.childCount - k).gameObject);
            }
        }
            else if (nbrPhotos == 6)
            {
                places[2].SetActive(true);
            for (int j = 12; j < places[2].transform.childCount-6; j++)
            {
                backPhoto.Add(item: places[2].transform.GetChild(j - 12).gameObject);
                photoFace.Add(item: places[2].transform.GetChild(j).gameObject);
                photoFace[i].transform.localScale = new Vector2(0, 0);
                i++;
            }
            for (int k = 6; k > 0; k--)
            {
                truue.Add(item: places[2].transform.GetChild(places[2].transform.childCount - k).gameObject);
            }
        }
            else if (nbrPhotos == 8)
                {
                    places[3].SetActive(true);
                    for (int j = 16; j < places[3].transform.childCount-8 ; j++)
                    {
                        backPhoto.Add(item: places[3].transform.GetChild(j - 16).gameObject);
                        photoFace.Add(item: places[3].transform.GetChild(j).gameObject);
                        photoFace[i].transform.localScale = new Vector2(0, 0);
                        i++;
                    }
                    
                }
        for (int k = 8; k > 0; k--)
        {
            truue.Add(item: places[3].transform.GetChild(places[3].transform.childCount - k).gameObject);
        }


    }

    void initialiserPhotos()
    {
        int[] indiceOfTxt = new int[nbrPhotos];
        if (nbrPhotos == 2)
        {
            indiceOfTxt[0] = Random.Range(0, Txt.Length);
            indiceOfTxt[1] = Random.Range(0, Txt.Length);
            while (indiceOfTxt[0] == indiceOfTxt[1])
            {
                indiceOfTxt[1] = Random.Range(0, Txt.Length);
            }
            for (int i = 0; i < photoFace.Count; i++)
            {
                if (i < photoFace.Count / 2)
                    photoFace[i].GetComponent<RawImage>().texture = Txt[indiceOfTxt[0]];
                else photoFace[i].GetComponent<RawImage>().texture = Txt[indiceOfTxt[1]];
            }
        }
        if (nbrPhotos == 4)
        {
            indiceOfTxt = rondom4Numbrs(Txt.Length);
            for (int i = 0; i < photoFace.Count; i++)
            {
                if (i < photoFace.Count / 2)
                    photoFace[i].GetComponent<RawImage>().texture = Txt[indiceOfTxt[i]];
                else photoFace[i].GetComponent<RawImage>().texture = Txt[indiceOfTxt[i-4]];
            }

        }

        if (nbrPhotos == 6)
        {
            int[] xxx = rondom4Numbrs(Txt.Length - 2);
            for (int i = 0; i < 4; i++)
                indiceOfTxt[i] = xxx[i];
            indiceOfTxt[4] = Txt.Length-2;
            indiceOfTxt[5] = Txt.Length-1;
            
            for (int i = 0; i < photoFace.Count; i++)
            {
                if (i < photoFace.Count / 2)
                    photoFace[i].GetComponent<RawImage>().texture = Txt[indiceOfTxt[i]];
                else photoFace[i].GetComponent<RawImage>().texture = Txt[indiceOfTxt[i - 6]];
            }
        }
        if (nbrPhotos == 8)
        {
            int[] xxx = rondom4Numbrs(Txt.Length - 4);
            for (int i = 0; i < 4; i++)
                indiceOfTxt[i] = xxx[i];
            indiceOfTxt[4] = Txt.Length - 4;
            indiceOfTxt[5] = Txt.Length - 3;
            indiceOfTxt[6] = Txt.Length - 2;
            indiceOfTxt[7] = Txt.Length - 1;

            for (int i = 0; i < photoFace.Count; i++)
            {
                if (i < photoFace.Count / 2)
                    photoFace[i].GetComponent<RawImage>().texture = Txt[indiceOfTxt[i]];
                else photoFace[i].GetComponent<RawImage>().texture = Txt[indiceOfTxt[i - 8]];
            }
        }
    }

    int[] rondom4Numbrs(int length)
    {
        int[] indiceOfTxt = new int[4];
        indiceOfTxt[0] = Random.Range(0, length);
        indiceOfTxt[1] = Random.Range(0, length);
        while (indiceOfTxt[0] == indiceOfTxt[1])
        {
            indiceOfTxt[1] = Random.Range(0, length);
        }
        indiceOfTxt[2] = Random.Range(0, length);
        while (indiceOfTxt[2] == indiceOfTxt[1] || indiceOfTxt[2] == indiceOfTxt[0])
        {
            indiceOfTxt[2] = Random.Range(0, length);
        }
        indiceOfTxt[3] = Random.Range(0, length);
        while (indiceOfTxt[3] == indiceOfTxt[1] || indiceOfTxt[3] == indiceOfTxt[0] || indiceOfTxt[3] == indiceOfTxt[2])
        {
            indiceOfTxt[3] = Random.Range(0, length);
        }
        return indiceOfTxt;
    }







    public void Onclic_Back(int indice)
    {
        clicked = true;
        if (nbrFaces < 2)
        {
            nbrFaces++;
            if(nbrFaces==1)
            FirstClicked = indice;
            if (nbrFaces == 2) secondClicked = indice;
            backPhoto[indice].transform.localScale = new Vector2(0, 0);
            if(nbrPhotos==8)
            photoFace[indice].transform.localScale = new Vector2(0.7f, 0.7f);
            else
            photoFace[indice].transform.localScale = new Vector2(1, 1);
        }
        
    }






    
    void chang2Element( int a , int b)
    {
        Texture aide;
        aide = photoFace[a].GetComponent<RawImage>().texture;
        photoFace[a].GetComponent<RawImage>().texture = photoFace[b].GetComponent<RawImage>().texture;
        photoFace[b].GetComponent<RawImage>().texture = aide;
    }
    void randomTxt()
    {
        if(nbrPhotos == 2)
        {
            int x = Random.Range(0, 4);
            int y = Random.Range(0, 4);
            while (x == y)
            {
                y = Random.Range(0, 4);
            }
            chang2Element(x, y);
        }

        if (nbrPhotos == 4)
        {
            int[] indiceOfTxt = rondom4Numbrs(8);

            chang2Element(indiceOfTxt[0], indiceOfTxt[3]);
            chang2Element(indiceOfTxt[1], indiceOfTxt[2]);
        }
    }

    void Start()
    {
        score = FindObjectOfType<Score>();
        if(nbrPhotos==2)
            score.initialiserStars(4);
        nbrFaces = 0;
        backPhoto.Clear();
        photoFace.Clear();
        truue.Clear();

        Inisialiser();
        initialiserPhotos();
        for(int i =0; i<4; i++)
        randomTxt();
        


    }

    // Update is called once per frame
    void Update()
    {
       if(!finish) timer_to_finish += Time.deltaTime;

        if (nbrFaces==2 && timer1>=0)
        {
            timer1 -= Time.deltaTime;
           
        }
        if (nbrFaces==2 && timer1 <= 0) 
        {
            if (photoFace[FirstClicked].GetComponent<RawImage>().texture == photoFace[secondClicked].GetComponent<RawImage>().texture)
            {
                truue[nbrItemsTrue].GetComponent<RawImage>().texture= photoFace[FirstClicked].GetComponent<RawImage>().texture;
                truue[nbrItemsTrue].SetActive(true);

                photoFace[FirstClicked].SetActive(false);
                photoFace[secondClicked].SetActive(false);
                nbrItemsTrue++;
                if(nbrItemsTrue == nbrPhotos)
                {
                    
                    nextButton.SetActive(true);
                   

                }

            }
            else
            {
                photoFace[FirstClicked].transform.localScale = photoFace[secondClicked].transform.localScale = new Vector2(0, 0);
                if(nbrPhotos==8)
                backPhoto[FirstClicked].transform.localScale = backPhoto[secondClicked].transform.localScale = new Vector2(0.7f, 0.7f);
                else
                backPhoto[FirstClicked].transform.localScale = backPhoto[secondClicked].transform.localScale = new Vector2(1, 1);
            }
            timer1 = 0.5F ;
            nbrFaces = 0;

        }
        if (nbrItemsTrue == nbrPhotos)
        {
            timer2 -= Time.deltaTime;
        }
        if (timer2 <= 0){
            nbrItemsTrue = 0;
            next = true;
            timer2 = 0.5f;
        }
        
            if (next && nbrPhotos == 2)
            {
            places[0].SetActive(false);
                nbrPhotos = 4;
                nextButton.SetActive(false);
            score.AddStar();
            Start();
                next = false;
            }
        
        else if (next && nbrPhotos == 4)
        {
            Destroy(places[1]);
            nbrPhotos = 6;
            nextButton.SetActive(false);
            score.AddStar();
            Start();
            next = false;
        }
        else if (next && nbrPhotos == 6)
        {
            Destroy(places[2]);
            nbrPhotos = 8;
            nextButton.SetActive(false);
            score.AddStar();
            Start();
            next = false;
        }
        else if (next && nbrPhotos == 8)
        {
            Destroy(places[3]);
            Debug.Log("you win");
            nextButton.SetActive(false);
            score.AddStar();
            Start();
            next = false;
            winScean[0].SetActive(true);
            winScean[1].SetActive(true);
            nextButton.SetActive(false);
            finish = true;
            add_data = true;
        }

        if (add_data)
        {
            add_Score_Db = FindObjectOfType<Add_Score_db>();
            if (PlayerPrefs.GetInt("id_user") != 0)
                add_Score_Db.UpdateData(PlayerPrefs.GetInt("id_user"), 14, 0, timer_to_finish);
            add_data = false;
        }
        }
  



}
