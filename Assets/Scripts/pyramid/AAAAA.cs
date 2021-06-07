using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAAAA : MonoBehaviour
{
    int nbrItems = 0;
    Vector2 Posi;
    AddIt c1;
   public bool IsLocked;

    
    // Start is called before the first frame update
    void Start()
    {
        c1 = FindObjectOfType<AddIt>();
        Posi = this.transform.position;
    }


    private void OnMouseDown()
    {
     
    }

    private void OnMouseDrag()
    {
        Vector2 MousePosi;
        MousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(!IsLocked)
        this.transform.position = MousePosi;



    }


    private void OnMouseUp()
    {
        if( this.transform.position.x<-2.13 && this.transform.position.x >-8.02  && !IsLocked )
        {
          if (c1.nbrI == 0)
           this.transform.position = new Vector2(-5f, -3.69f);
          if (c1.nbrI == 1)
           this.transform.position = new Vector2(-5f, -2.48f);
           if (c1.nbrI == 2)
           this.transform.position = new Vector2(-5f, -1.34f);
           if (c1.nbrI == 3)
           this.transform.position = new Vector2(-5f, -0.26f);
           if (c1.nbrI == 4)
           this.transform.position = new Vector2(-5f, 0.71f);
           if (c1.nbrI == 5)
           this.transform.position = new Vector2(-5f, 1.68f);
           if (c1.nbrI == 6)
           this.transform.position = new Vector2(-5f, 2.63f);
           if (c1.nbrI == 7)
            {
                this.transform.position = new Vector2(-5f, 3.88f);
            }


            IsLocked = true;
            c1.nbrI++;
        }

        else if(!(this.transform.position.x < -2.13 && this.transform.position.x > -8.02) && !IsLocked )
        this.transform.position = Posi;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
