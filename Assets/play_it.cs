using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class play_it : MonoBehaviour
{
    // Start is called before the first frame update
    
   public void playIt()
    {
        int x = Random.Range(1, 11);
        SceneManager.LoadScene(x, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
