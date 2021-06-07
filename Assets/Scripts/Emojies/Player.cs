using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int player;
    EmojiesController emojiesController;
    // Start is called before the first frame update
    void Start()
    {
        emojiesController = FindObjectOfType<EmojiesController>();
    }

    private void OnMouseDown()
    {
        emojiesController.check(player);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
