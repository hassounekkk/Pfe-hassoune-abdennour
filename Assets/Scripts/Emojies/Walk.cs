using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    bool left;
    bool right = true;
    public float speed = 1;
    public Collider2D[] collider2D;
    Collider2D thisCollider2D;
    public float rightPosi;
    public float leftPosi;
    // Start is called before the first frame update
    void Start()
    {
        thisCollider2D = this.GetComponent<Collider2D>();

        for(int i = 0; i < collider2D.Length; i++)
        {
            Physics2D.IgnoreCollision(thisCollider2D, collider2D[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (right )
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }

        if (left )
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (transform.position.x < leftPosi)
        {
            left = true;
            right = false;
        }
        if (transform.position.x > rightPosi)
        {
            left = false;
            right = true;
        }

    }
}
