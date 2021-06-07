using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AHH : MonoBehaviour
{
    Animator animator;
    bool right=true, left;
    Rigidbody2D rig;
    float speed;

    public bool locked = false;
    public float rightPosi_X;
     float rightPosi_y;
    public GameObject secondPlan;
    Collider2D secondPlanCollider;

    SpriteRenderer spriteRenderer;

   

    public GameObject[] kass;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        animator = this.GetComponent<Animator>();
        rig = this.GetComponent<Rigidbody2D>();
        rig.freezeRotation = true;

        secondPlanCollider = secondPlan.GetComponent<Collider2D>();

        speed = Random.Range(1 , 4);

        for(int i = 0; i<kass.Length; i++)
        {
            if (spriteRenderer.color == kass[i].GetComponent<SpriteRenderer>().color)
            {
                rightPosi_X = kass[i].transform.position.x;
            }
        }

        rightPosi_y = kass[0].transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (right && !locked)
        {
            transform.position += new Vector3(-speed, 0, 0)*Time.deltaTime;
        }
        
        if (left && !locked)
        {
            transform.position += new Vector3(speed,0,0) * Time.deltaTime;
        }
        if(transform.position.x < -7)
        {
            left = true;
            right = false;
        }
        if(transform.position.x > 7)
        {
            left = false;
            right = true;
        }

        if (locked)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), secondPlanCollider , false);
            

        }
    }

    private void OnMouseDrag()
    {
        animator.SetBool("xxx", true);
        Vector2 MousePo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!locked)
        {
            transform.position = MousePo;
        }
    }
    private void OnMouseUp()
    {
        if(transform. position.y < rightPosi_y + 2.5f && transform.position.y > rightPosi_y - 2 && transform.position.x < rightPosi_X + 1.5 && transform.position.x > rightPosi_X - 1.5)
        {
            this.transform.localScale -= new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z / 2);
            locked = true;
        }

        animator.SetBool("xxx", false);
        
    }

}
