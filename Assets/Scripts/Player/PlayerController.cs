using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status {idle,moving,jumping,running}

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 7f;
    public float gravity = -9.81f;
    public PlayerInput PlayerInput;
    public Status status;
     



    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag(PlayerComponents.Player).GetComponent<CharacterController>();
        PlayerInput = GameObject.FindGameObjectWithTag(PlayerComponents.Player).GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.right * PlayerInput.x + transform.forward * PlayerInput.z;

        if (move != null)
        {
            controller.Move(move * speed * Time.deltaTime);

           // if (speed == 12f)
            //{
                status = Status.moving;
           // }
            //velocity.y += gravity * Time.deltaTime;

            controller.Move(PlayerInput.velocity * Time.deltaTime);
            
        }
        if(PlayerInput.x==0f && PlayerInput.z==0f)
        {
            status = Status.idle;
            //PlayerInput.isRunning = false;
        }
        if (PlayerInput.isGrounded==false)
        {
            status = Status.jumping;
           // PlayerInput.isRunning = false;
            //Debug.Log("shoot");
        }
        if (PlayerInput.isRunning == true && status==Status.moving)
        {
            status = Status.running;
        }

        


        
    }

   // public void UpdateStatusJump()
   // {
   //     status = Status.jumping;
   //}
}
