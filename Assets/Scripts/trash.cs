using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class trash : MonoBehaviour
{
    public GameObject ScoreText;
    public GameObject HighScoreText;
    public int theScore;



    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "metal")
        {
            theScore += 1;
            ScoreText.GetComponent<Text>().text = "Score: " + theScore;
            if (theScore == 1) {
                SceneManager.LoadScene("2map");
            }
        }
        else if (other.gameObject.tag == "glass" || other.gameObject.tag == "paper")
        {
            theScore -= 1;
            ScoreText.GetComponent<Text>().text = "Score: " + theScore;
        }
        if (theScore > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", theScore);
            HighScoreText.GetComponent<Text>().text = "High Score: " + theScore.ToString();
            Application.Quit();
        }

    }
    //public void Reset()
   // {
    //    PlayerPrefs.DeleteAll();
    //    HighScoreText.GetComponent<Text>().text = "0";
   // }


}
