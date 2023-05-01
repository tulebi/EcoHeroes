using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class intro : MonoBehaviour
{
    VideoPlayer video;
    public GameObject MainMenu;
    public GameObject Sound;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        video = GetComponent<VideoPlayer>();
        MainMenu.SetActive(false);
        Sound.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        var intro_time = video.time;
        if (intro_time > 38)
        {
            Time.timeScale = 1;
            video.enabled = false;
            MainMenu.SetActive(true);
            Sound.SetActive(true);
            
        }

    }
}