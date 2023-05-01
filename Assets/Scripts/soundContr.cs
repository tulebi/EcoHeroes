using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundContr : MonoBehaviour
{
    AudioSource backSound;
    // Start is called before the first frame update
    void Start()
    {
        backSound = GetComponent<AudioSource>();
        backSound.PlayDelayed(38.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}