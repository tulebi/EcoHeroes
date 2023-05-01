using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kozgals : MonoBehaviour
{
    // public AudioClip[] footsteps;

    public Text timer;
    public float wastime = 30;
    public gameover gameover;
    private GameObject BackSound;
    public int k = 0;
    public static Kozgals instance;

    //AudioSource playerAudio;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;
    private bool mapcheck;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    //Preferences
    private CharacterController controller;
    private Animator anim;






    public void Start()
    {
        StartCoroutine(health());
        BackSound = GameObject.Find("backSound");

        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        //playerAudio = GetComponent<AudioSource>();

    }

    





    private void Update()
    {

        timer.text = wastime.ToString();
        if (wastime <= 0)
        {
            gameover.Setup(30);
            BackSound.SetActive(false);

        }

        Move();
        if (Input.GetKeyDown(KeyCode.T))
        {
            anim.SetTrigger("Dance");
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "123")
        {
            wastime -= 3;
        }

    }


    IEnumerator health()
    {
        while (true)
        {

            yield return new WaitForSeconds(1);
            wastime -= 1;

        }
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (!isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }


        controller.Move(moveDirection);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }
    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }
    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -4 * gravity);
    }
    


    private void Awake()
    {
        instance = this;
    }
    //private IInventoryItem mItemToPickup = null;

    

}
