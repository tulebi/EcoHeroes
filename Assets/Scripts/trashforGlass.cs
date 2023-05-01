using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class trashforGlass : MonoBehaviour
{
    public GameObject ScoreText;
    public GameObject HighScoreText;
    public GameObject ant;
    private trash intScore;



    // Start is called before the first frame update
    void Start()
    {
        intScore = ant.GetComponent<trash>();
        HighScoreText.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "glass")
        {
            intScore.theScore += 1;
            ScoreText.GetComponent<Text>().text = "Score: " + intScore.theScore;
            if (intScore.theScore == 26)
            {
                SceneManager.LoadScene("2map");
            }
        }
        else if (other.gameObject.tag == "metal" || other.gameObject.tag == "paper")
        {
            intScore.theScore -= 1;
            ScoreText.GetComponent<Text>().text = "Score: " + intScore.theScore;
        }
        if (intScore.theScore > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", intScore.theScore);
            HighScoreText.GetComponent<Text>().text = "High Score: " + intScore.theScore.ToString();
            Application.Quit();
        }
    }
    //public void Reset()
    // {
    //    PlayerPrefs.DeleteAll();
    //    HighScoreText.GetComponent<Text>().text = "0";
    // }


}
