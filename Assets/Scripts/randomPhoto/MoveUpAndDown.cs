using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    bool isUping = false;
    bool isDowning = false;
  

    Vector2 position_initial;
    Vector2 firstTouch;
    public int indice = 0;
     ObjectController objectController;
    // Start is called before the first frame update
    void Start()
    {
        objectController = GameObject.FindObjectOfType<ObjectController>();
        position_initial = transform.position;
        UpdatePosition();
    }

   public  void UpdatePosition()
    {
        if (transform.position.y > 3 && transform.position.y < 4)
            indice = 0;
        else if (transform.position.y > 1.5 && transform.position.y < 2.5)
            indice = 1;
        else if (transform.position.y > 0 && transform.position.y < 1)
            indice = 2;
        else if (transform.position.y > -1 && transform.position.y < 0)
            indice = 3;
        else if (transform.position.y > -2.5 && transform.position.y < -1)
            indice = 4;
        else if (transform.position.y >= -5 && transform.position.y < -2)
            indice = 5;

    }

    private void OnMouseDown()
    {
        UpdatePosition();

        firstTouch = transform.position;
    }
    private void OnMouseDrag()
    {
       
        Vector2 touchePoisition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(transform.position.x, touchePoisition.y);

        if (((firstTouch.y - transform.position.y) < -0.6) && indice > 0)
        {
            isUping = true;
        }
        else if ((firstTouch.y - transform.position.y) > 0.6)
        {
            isDowning = true;
        }
    }
    private void OnMouseUp()
    {
        if (isDowning)
        {
          
            objectController.change(indice, true);
            isUping = isDowning = false;
            UpdatePosition();
        }
        else if (isUping)
        {
            
            objectController.change(indice, false);
            isUping = isDowning = false;
            UpdatePosition();
        }
        else transform.position = position_initial;
        UpdatePosition();
    }



}
