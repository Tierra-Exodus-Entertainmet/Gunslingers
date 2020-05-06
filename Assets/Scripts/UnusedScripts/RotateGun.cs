using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public Grapple grappling;
    private Quaternion DestinationRotation;
    private float RotSpeed = 5f;


    // Update is called once per frame
    void Update()
    {
        if (!grappling.isGrappling())
        {
            DestinationRotation = transform.parent.rotation;
        }

        else
        {
            DestinationRotation = Quaternion.LookRotation(grappling.getGrapplePoint() - transform.position);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, DestinationRotation, Time.deltaTime * RotSpeed);



        
    }
}
