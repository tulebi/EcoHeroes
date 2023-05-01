using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int theScore)
    {
        gameObject.SetActive(true);
        pointsText.text = "TIME IS OVER";
        Cursor.lockState = CursorLockMode.None;
    }

    public void restartbutton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void restartbutton2()
    {
        SceneManager.LoadScene("2map");
    }

    public void exitbutton()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
