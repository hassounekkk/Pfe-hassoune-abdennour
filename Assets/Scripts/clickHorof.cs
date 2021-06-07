using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickHorof : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDrag()
    {
        Vector2 MousePo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = MousePo;
    }

}
