using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qqq : MonoBehaviour
{
    public Collider2D plan;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), plan );
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
