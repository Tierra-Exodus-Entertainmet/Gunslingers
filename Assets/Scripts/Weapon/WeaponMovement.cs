using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public Animator anim;
    public PlayerController playerController;
   // public Camera _cam;

    public GameObject Weapon;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        playerController = GameObject.FindGameObjectWithTag(PlayerComponents.Player).GetComponent<PlayerController>();
       // _cam = GameObject.FindGameObjectWithTag(Cam.MainCamera).GetComponent<Camera>();

        Weapon = GameObject.FindGameObjectWithTag(Weapons.Gun);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.status == Status.moving)
        {
           // anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", true);
            anim.SetFloat("speed", 1);
           // _cam.fieldOfView = 60;
        }
       else if(playerController.status==Status.running)
       {
            //anim.SetBool("isWalking", false);
            //anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", true);
            anim.SetFloat("speed", 2f);

           // _cam.fieldOfView = 70;

        }
       // else if(playerController.status == Status.jumping)
       // {
           //StartCoroutine(UpwardPush());
       // }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("speed", 1);
            //_cam.fieldOfView = 60;
            // anim.SetBool("isRunning", false);
        }
        
    }

    //public IEnumerator UpwardPush()
   // {
   //     Weapon.transform.Rotate(20f, 0f, 0f);
  //      yield return new WaitForSeconds(0.2f);
   //     Weapon.transform.Rotate(-20f, 0f, 0f);
   // }
}
