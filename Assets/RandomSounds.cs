using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    AudioSource source;
    AudioClip ambience1;

    public float ambience1Chance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        float _ran = Random.Range(0.00f, 1.00f);

        if(_ran < ambience1Chance)
        {
            source.clip = ambience1;
            source.Play();
        }
    }
}
