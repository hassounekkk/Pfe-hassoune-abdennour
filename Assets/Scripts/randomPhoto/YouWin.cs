using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{
    
    public MoveUpAndDown[] M;
    public GameObject win;
    public GameObject next;
    public GameObject restart;
    public AudioSource rightt;
    bool right;
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
        if(M[0].indice == 0 && M[1].indice == 1 && M[2].indice == 2 && M[3].indice == 3 && M[4].indice == 4 && M[5].indice == 5)
        {
            rightt.Play();
            right = true;
            
            
        }
        else
        {
            right = false;
        }

        if (right)
        {
            win.SetActive(true);
            next.SetActive(true);
            
            restart.SetActive(true);
        }
        else
        {
            win.SetActive(false);
            next.SetActive(false);
            restart.SetActive(false);
        }
        
    }
}
