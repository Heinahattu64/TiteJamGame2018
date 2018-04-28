﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobbycontrol : MonoBehaviour {

    public float rotaterate;
    private Rigidbody rb;

    public GameObject windyzone;
    public bool inWindZone;

    public float jumpTimer;
    public float jumpPower;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        MoveBlobby();
	}

    void MoveBlobby()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotaterate;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * rotaterate;

        Vector3 movement = new Vector3(x, 0.0f, z);
        rb.AddForce(movement);

        jumpTimer -= Time.deltaTime;

        if (jumpTimer <= 0.0f && Input.GetButtonDown("Jump"))
        {
            Vector3 jump = new Vector3(0.0f, jumpPower, 0f);
            rb.AddForce(jump);
            jumpTimer = 1.5f;
        }
    }

    private void FixedUpdate()
    {
        if (inWindZone)
        {
            rb.AddForce(windyzone.GetComponent<windArea>().windDirection * windyzone.GetComponent<windArea>().windStrength);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "windArea")
        {
            windyzone = coll.gameObject;
            inWindZone = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.tag == "windArea")
        {
            inWindZone = false;
        }
    }
}