using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Head;
    //public GameObject Orientation;

    //float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        Head = GameObject.FindGameObjectWithTag(PlayerComponents.Head);
       // Orientation = GameObject.FindGameObjectWithTag(PlayerComponents.Orientation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Head.transform.position;
        //transform.rotation = Head.transform.rotation;

      // xRotation = Orientation.GetComponent<MouseLook>().xRotation;
       



    }
}
