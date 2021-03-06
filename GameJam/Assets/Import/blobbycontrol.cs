﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobbycontrol : MonoBehaviour
{

    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;

    public GameObject windyzone;
    public Transform camMain;
    public Transform anchor;
    public bool inWindZone;

    public float jumpTimer;
    public float jumpPower;
    public float hopPower;
    public float hopTimer;
    public float hopTimerReset;


    //public CamAnchor anchorScript;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        MoveBlobby();
        HopBlobby();

    }

    void MoveBlobby()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime;
        /*
        //anchorScript.MovementTry();

        //CamAnchor gimmescript = anchor.GetComponent<CamAnchor>();

        Vector3 dir = new Vector3(x, 0, z);
        Quaternion rotation = Quaternion.Euler(x, 0, z);
        camMain.position = anchor.position + rotation * dir;
        camMain.LookAt(anchor.position);
        camMain.LookAt(anchor.position);

        
        Vector3 test = camMain.position;
        Quaternion trying = camMain.localRotation;
        //anchor.rotation = Quaternion.LookRotation(test);

        anchor.transform.localRotation = Quaternion.Slerp(trying, anchor.rotation, Time.deltaTime);
        

        rb.AddForce(dir);
        */

        //Vector3 movement = new Vector3(z, 0, 0);
        transform.Rotate(0, x, 0);

        if (z > 0)
        {
            rb.AddForce(transform.forward * moveSpeed);
        }
        else if (z < 0)
        {
            rb.AddForce(transform.forward * -moveSpeed);
        }
        //rb.AddForce(transform.forward);

        jumpTimer -= Time.deltaTime;
        if (jumpTimer <= 0.0f && Input.GetButtonDown("Jump"))
        {
            Vector3 jump = new Vector3(0.0f, jumpPower, 0f);
            rb.AddForce(jump);
            jumpTimer = 1.5f;
        }
    }
    void HopBlobby()
    {

        hopTimer -= Time.deltaTime;

        if (hopTimer <= 0f)
        {
            Vector3 hop = new Vector3(0.0f, hopPower, 0f);
            rb.AddForce(hop);
            hopTimer = hopTimerReset;
        }
    }

    private void FixedUpdate()
    {

    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "windArea")
        {
            windyzone = coll.gameObject;
            inWindZone = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "windArea")
        {
            inWindZone = false;
        }
    }
}
