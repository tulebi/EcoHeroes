using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupdrop : MonoBehaviour
{
    private Transform PickUpPoint;
    private Transform player;

    //public GameObject bag;

    public float pickupDistance;
    public float forceMulti;

    public bool readyToThrow;
    public bool itemIsPicked;

    private Rigidbody rb;
    public AudioSource Sound;
    public AudioSource Sound2;
    Outline outline;

    void Start()
    {
        //bag.SetActive(false);

        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Bala").transform;
        PickUpPoint = GameObject.Find("PickUpPoint").transform;
        outline = GetComponent<Outline>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && itemIsPicked == true && readyToThrow)
        {
            forceMulti += 300 * Time.deltaTime;
        }
        pickupDistance = Vector3.Distance(player.position, transform.position);

        if (pickupDistance <= 2)
        {

            if (Input.GetKeyDown(KeyCode.E) && itemIsPicked == false && PickUpPoint.childCount < 1)
            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<BoxCollider>().enabled = false;
                this.transform.position = PickUpPoint.position;
                this.transform.parent = GameObject.Find("PickUpPoint").transform;
                Sound.Play();
                outline.enabled = false;
                itemIsPicked = true;
                forceMulti = 0;
                //bag.SetActive(true);
            }
        }
        if (Input.GetKeyUp(KeyCode.E) && itemIsPicked == true)
        {
            readyToThrow = true;

            if (forceMulti > 10)
            {
                rb.AddForce(player.transform.forward * forceMulti);
                this.transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<BoxCollider>().enabled = true;
                itemIsPicked = false;
                Sound2.Play();
                forceMulti = 0;
                readyToThrow = false;
                outline.enabled = true;
            }
            forceMulti = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "trashbag")
        {
            Destroy(gameObject);
        }
    }
}