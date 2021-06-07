using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationCtr : MonoBehaviour
{
    // Start is called before the first frame update

    bool finish;
    float timer_to_finish;

    Add_Score_db add_Score_Db;

    public GameObject[] PhotoKamla;
    public List<GameObject> trifat = new List<GameObject>();
    int curPhoto=0;
    int level = 0;
    bool right;
    bool startCkecking;
    public GameObject momiko;
    float Timer = 3;
   public float TimerToChange = 3;
    void Start()
    {
        
        if (level == 3) { level = 0; curPhoto++; startCkecking = false; }
            momiko.SetActive(false);
        trifat.Clear();
        right = false;
        startCkecking = false;
        for (int i = 0; i < PhotoKamla[curPhoto].transform.GetChild(level).transform.childCount; i++)
        {
            trifat.Add(PhotoKamla[curPhoto].transform.GetChild(level).transform.GetChild(i).gameObject);
        }
        foreach (GameObject Tr in trifat) Tr.SetActive(true);

        
    }

    void RotateIt()
    {
        int[] x;
        if (level == 0)
        {
            x = randomTwo();
            trifat[x[0]].transform.rotation = new Quaternion(0, 0, -90, 0);
            trifat[x[1]].transform.rotation = new Quaternion(0, 0, 270, 0);
        }
        else
        {
            x = randomTree();
            trifat[x[0]].transform.rotation = new Quaternion(0, 0, -90, 0);
            trifat[x[1]].transform.rotation = new Quaternion(0, 0, 270, 0);
            trifat[x[2]].transform.rotation = new Quaternion(0, 0, 180, 0);
        }
    }

    int[] randomTree()
    {
        int[] a = new int[3];
        a[0] = Random.Range(0, trifat.Count);
        a[1] = Random.Range(0, trifat.Count);
        while (a[1] == a[0]) a[1] = Random.Range(0, trifat.Count);
        a[2] = Random.Range(0, trifat.Count);
        while (a[2] == a[0] || a[2] == a[1]) a[2] = Random.Range(0, trifat.Count);
        return a;
    }
    int[] randomTwo()
    {
        int[] a = new int[2];
        a[0] = Random.Range(0, 4);
        a[1] = Random.Range(0, 4);
        while (a[1] == a[0]) a[1] = Random.Range(0, 4);
        return a;
    }


    void checkIt()
    {
        right = true;
        
        foreach(GameObject gameObject in trifat)
        {
            if (gameObject.transform.rotation.z != 0) right = false;
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        if (!finish) timer_to_finish += Time.deltaTime;

        if (!startCkecking)
        {
            Timer -= Time.deltaTime;
        }
        if (Timer <= 0)
        {
            Timer = 3;
            startCkecking = true;
            RotateIt();
        }
        if(startCkecking)
        checkIt();
        if (right)
        {
            TimerToChange -= Time.deltaTime;
            momiko.SetActive(true);
            
           
        }
        if (TimerToChange <= 0)
        {
            level++;
            
            foreach (GameObject Tr in trifat) Tr.SetActive(false);
             Start();
            TimerToChange = 3;
            right = false;
        }
        
    }
}
