using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobbycontrol : MonoBehaviour {

    public float rotaterate;
    private Rigidbody rb;

    public GameObject windyzone;
    public Transform camMain;
    public Transform anchor;
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

        Vector3 dir = new Vector3(x, 0, z);
        Quaternion rotation = Quaternion.Euler(x, 0, z);
        camMain.position = anchor.position + rotation * dir;
        camMain.LookAt(anchor.position);

        //Vector3 movement = new Vector3(x, 0, z);
        rb.AddForce(dir);
        
        //rb.AddForce(dir);

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
