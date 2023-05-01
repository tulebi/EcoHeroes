using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTimer : MonoBehaviour
{
    AudioSource backSound;
    // Start is called before the first frame update
    void Start()
    {
        backSound = GetComponent<AudioSource>();
        Invoke("playAudio", 38.0f);
    }

    // Update is called once per frame
    void playAudio()
    {
        backSound.Play();
    }
}