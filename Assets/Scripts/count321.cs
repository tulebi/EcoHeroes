using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class count321 : MonoBehaviour
{
    
    public int countdownTime;
    public Text countdownText;
    
    private void Start()
    {
        StartCoroutine(CountDownToStart());
    }
    IEnumerator CountDownToStart()
    {
        while(countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownText.text = "GO!";
        Kozgals.instance.Start();
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
        
    }

}
