using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Photos : MonoBehaviour
{
    public GameObject starPrefab;
    public GameObject starPrefab1;
    Vector2 starPosition = new Vector2(-9 , -4);
    List<GameObject> prefab = new List<GameObject>();
    List<GameObject> prefab2 = new List<GameObject>();
    Vector2 starPosition1 = new Vector2(-9, -4);
    public GameObject[] photo;
    public GameObject all;
    public GameObject fin;
    public AudioSource winningSound;
    
    public ObjectController[] objectController;
    int indice = 0;
    // Start is called before the first frame update
    public void Start()
    {

        for(int i = 0; i < objectController.Length; i++)
        {
            objectController[i].rondomObjects();
        }

        indice = 0;
        fin.SetActive(false);
        all.SetActive(true);

        for(int i =0; i<photo.Length; i++)
        {
            photo[i].SetActive(false);
        }

        photo[indice].SetActive(true);
        for (int i = 0; i < photo.Length; i++)
        {
           prefab.Add(Instantiate(starPrefab ,starPosition , Quaternion.identity));
            starPosition.x += 0.7f;
        }

    }

    public void distroyIt()
    {
        foreach(GameObject gameObject in prefab)
        {
            Destroy(gameObject);
        }
        foreach (GameObject gameObject in prefab2)
        {
            Destroy(gameObject);
        }
        starPosition = starPosition1 = new Vector2(-9, -4);
    }

    public void changeScene(int n)
    {
        SceneManager.LoadScene(n, LoadSceneMode.Single);
    }

    public void change()
    {
        /*   if (indice != photo.Length)
           {
               photo[indice].SetActive(false);
           }
           if (indice < photo.Length-1)
           {
               indice++;
               photo[indice].SetActive(true);
           }
           if (indice == photo.Length )
           {
               all.SetActive(false);
               fin.SetActive(true);
           }
           else
           {
               all.SetActive(true);
               fin.SetActive(false);
           }*/
        photo[indice].SetActive(false);
        if (indice <= photo.Length)
        {
            indice++;
        }
        if (indice < photo.Length )
        {
            
            photo[indice].SetActive(true);
           

        }
        if (indice == photo.Length)
        {
            all.SetActive(false);
            fin.SetActive(true);
            winningSound.Play();
        }
        else
        {
            all.SetActive(true);
            fin.SetActive(false);
        }

        prefab2.Add(Instantiate(starPrefab1, starPosition1, Quaternion.identity));
        starPosition1.x += 0.7f;



    }

    void Update()
    {
        
    }
}
