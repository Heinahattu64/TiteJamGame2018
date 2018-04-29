using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float rotaterate;
    private Rigidbody rb;

    public GameObject windyzone;
    public bool inWindZone;

    public float jumpPower;
    public float hopPower;
    public float hopTimer;
    public float hopTimerReset;

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
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotaterate;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * rotaterate;

        Vector3 movement = new Vector3(x, 0.0f, z);

        rb.AddForce(movement);

        if (Input.GetButtonDown("Jump"))
        {
            Vector3 jump = new Vector3(0.0f, jumpPower, 0f);

            rb.AddForce(jump);
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
        if (inWindZone && gameObject.tag == "Player")
        {
            rb.AddForce(windyzone.GetComponent<windArea>().windDirection * windyzone.GetComponent<windArea>().windStrength);
        }
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