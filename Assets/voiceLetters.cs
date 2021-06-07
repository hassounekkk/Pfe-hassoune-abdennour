using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voiceLetters : MonoBehaviour
{
    public AudioSource[] voice;
    public GameObject[] Leters;
    List<GameObject> letters = new List<GameObject>();
    int curLetter;

    // Start is called before the first frame update
    void Start()
    {

         curLetter = Random.Range(0, voice.Length);

        letters.Add(Instantiate(Leters[curLetter], new Vector3(0, 0, 0), Quaternion.identity));
        
    }

    public void speek()
    {
        voice[curLetter].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
