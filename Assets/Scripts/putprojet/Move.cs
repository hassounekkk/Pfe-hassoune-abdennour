using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 ObjectGoal;
    Vector2 position_initial;
    Vector2 mousePos;
    float deltaX, deltaY;
    bool locked;
    public GameObject xxx;
    public ControlGame A1;
    public AudioSource right;
    public AudioSource touch;

    private void Awake()
    {
        
    }

    void Start()
    {
        A1 = GameObject.FindObjectOfType<ControlGame>();
        ObjectGoal = A1.Goal();
        position_initial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObjectGoal = A1.Goal();
        if (Input.touchCount > 0 && !locked)
        {

            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition))
                    {
                        deltaX = touchPosition.x - transform.position.x;
                        deltaY = touchPosition.y - transform.position.y;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition))
                    {
                        transform.position = new Vector2(touchPosition.x - deltaX, touchPosition.y - deltaY);
                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - ObjectGoal.x) <= 0.5f && Mathf.Abs(transform.position.y - ObjectGoal.y) <= 0.5f)
                    {
                        transform.position = new Vector2(ObjectGoal.x, ObjectGoal.y);
                        locked = true;
                    }
                    else
                        transform.position = position_initial;
                    break;

            }
        }

    }

    private void OnMouseDown()
    {
        if (!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
            touch.Play();
        }


    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - ObjectGoal.x) <= 0.5f && Mathf.Abs(transform.position.y - ObjectGoal.y) <= 0.5f)
        {
            transform.position = new Vector2(ObjectGoal.x, ObjectGoal.y);
            locked = true;
            right.Play();
            A1.LoadNextOne();
        }
        else
            transform.position = position_initial;


    }

    private void OnMouseDrag()
    {

        if (!locked)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x - deltaX, mousePos.y - deltaY);


        }
    }

}
