using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task1 : MonoBehaviour
{
    public bool EndDialog;
    public bool EndDialog2;
    public GameObject Dialog1;
    public GameObject Dialog2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EndDialog == true)
        {
            Dialog1.SetActive(false);
            Dialog2.SetActive(true);
        }
        if (EndDialog2 == true)
        {
            Dialog2.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Dialog1.SetActive(true);
        }
    }
}