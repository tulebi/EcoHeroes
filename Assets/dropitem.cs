using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropitem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
