using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject StareWhite;
    public GameObject Stare;
    int CurLevel;
    ObjectController objectController;
    Vector2 PositionS = new Vector2(-9, -4.5f) ;
    Vector2 PositionST = new Vector2(-9 , -4.5f) ;
    List<GameObject> starsVide = new List<GameObject>();
    List<GameObject> stars= new List<GameObject>();
    int nbrOfStars;
    Vector2 StarScal;
    public AudioSource yeass;
    // Start is called before the first frame update
    void Start()
    {

        StarScal = Stare.transform.localScale;
        StareWhite.transform.localScale = Vector2.zero;
        Stare.transform.localScale = new Vector2(0.5f, 0.5f);

      
    }

    public void initialiserStars(int x)
    {
        nbrOfStars = x;
        go();
    }
    void go()
    {
        for (int i = 0; i < nbrOfStars; i++)
        {
            starsVide.Add(Instantiate(StareWhite, PositionS, Quaternion.identity));
            starsVide[i].LeanScale(new Vector2(0.1f ,  0.1f), 1) ;
            PositionS.x += 0.7f;
        }
    }
   public void AddStar()
    {
        stars.Add(Instantiate(Stare, PositionST, Quaternion.identity));
        PositionST.x += 0.7f;
        stars[CurLevel].LeanScale(new Vector2(0.1f, 0.1f), 1);
        CurLevel++;
        yeass.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
