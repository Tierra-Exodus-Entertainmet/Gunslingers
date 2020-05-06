using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    // public CharacterController controller;

    public PlayerController PlayerController;
    public GameObject Head;
   // public GameObject Capsule;
   // public GameObject cam;
    //public float speed = 12f;
    public float gravity = -9.81f;
    public Vector3 velocity;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    public float Jumpheight = 3f;
    [HideInInspector]
    public bool isGrounded;
    public bool isRunning;

    public float x;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        //controller = GameObject.FindGameObjectWithTag(PlayerComponents.Player).GetComponent<CharacterController>();
        PlayerController = GameObject.FindGameObjectWithTag(PlayerComponents.Player).GetComponent<PlayerController>();
        Head = GameObject.FindGameObjectWithTag(PlayerComponents.Head);
       //Capsule = GameObject.FindGameObjectWithTag(PlayerComponents.Capsule);
       // cam = GameObject.FindGameObjectWithTag(Cam.MainCamera);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        x = Input.GetAxis(Axis.HORIZONTAL);
        z = Input.GetAxis(Axis.VERTICAL);

        Vector3 move = transform.right * x + transform.forward * z;

        //controller.Move(move*speed*Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && PlayerController.status == Status.idle)
        {
            //PlayerController.status = Status.jumping;
            //PlayerController.UpdateStatusJump();
            velocity.y = 0.6f * Mathf.Sqrt(Jumpheight * -2f * gravity);
        }
        if (Input.GetButtonDown("Jump") && isGrounded && PlayerController.status == Status.moving)
        {
            //PlayerController.status = Status.jumping;
            // PlayerController.UpdateStatusJump();
            velocity.y = 1.2f * Mathf.Sqrt(Jumpheight * -2f * gravity);
        }
        if (Input.GetButtonDown("Jump") && isGrounded && PlayerController.status == Status.running)
        {
            //PlayerController.status = Status.jumping;
            // PlayerController.UpdateStatusJump();
            velocity.y = 1.6f * Mathf.Sqrt(Jumpheight * -2f * gravity);
        }
        PlayerController.speed = Input.GetKey(KeyCode.LeftShift) ? 14f : 7f;

        if (PlayerController.speed == 14f)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

     
       // if (Input.GetKey(KeyCode.LeftShift) && PlayerController.status == Status.moving)
        //{
          //  PlayerController.speed = 20f;
            //isRunning = true;
        //}
       // else
       // {
        //    isRunning = false;
         //   PlayerController.speed = 12f;
        //}
        


        velocity.y += gravity * Time.deltaTime;

        //controller.Move(velocity*Time.deltaTime);
    }
}
