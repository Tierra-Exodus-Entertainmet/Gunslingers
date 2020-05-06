using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 GrapplePoint;
    public LayerMask WhatToGrapple;
    public Transform GunTip, Camera,player;
    private SpringJoint joint;
    //public bool isGrappling;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();

    }
    private void LateUpdate()
    {
        DrawRope();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            StartGrapple();
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            StopGrapple();
        }
    }

    public void StartGrapple()
    {
        RaycastHit Hit;
        if(Physics.Raycast(origin:Camera.position , direction: Camera.forward,out Hit, maxDistance: 100f,WhatToGrapple))
        {
            GrapplePoint = Hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = GrapplePoint;

            float DistancefromPoint = Vector3.Distance(a: player.position, b: GrapplePoint);

            joint.maxDistance = DistancefromPoint * 0.8f;
            joint.minDistance = DistancefromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
    }

    void DrawRope()
    {
        if (!joint) return;


        lr.SetPosition(0, GunTip.position);
        lr.SetPosition(1, GrapplePoint);
    }
    public void StopGrapple()
    {
        lr.positionCount = 0;

        Destroy(joint);

    }
    public bool isGrappling()
    {
        return joint != null;
    }
    public Vector3 getGrapplePoint()
    {
        return GrapplePoint;
    }
}
