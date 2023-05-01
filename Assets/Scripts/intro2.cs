using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class intro2 : MonoBehaviour
{
    VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        video = GetComponent<VideoPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        var intro_time = video.time;
        if (intro_time > 38)
        {
            Time.timeScale = 1;
            video.enabled = false;
           // SceneManager.LoadScene("2map");
        }

    }
}