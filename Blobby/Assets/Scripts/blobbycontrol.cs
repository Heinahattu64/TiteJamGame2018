using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobbycontrol : MonoBehaviour {

    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;

    public GameObject windyzone;
    public Transform camMain;
    public Transform anchor;
    public bool inWindZone;

    public float jumpTimer;
    public float jumpPower;

    //public CamAnchor anchorScript;

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
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        /*
        //anchorScript.MovementTry();

        //CamAnchor gimmescript = anchor.GetComponent<CamAnchor>();

        Vector3 dir = new Vector3(x, 0, z);
        Quaternion rotation = Quaternion.Euler(x, 0, z);
        camMain.position = anchor.position + rotation * dir;
        camMain.LookAt(anchor.position);

        
        Vector3 test = camMain.position;
        Quaternion trying = camMain.localRotation;
        //anchor.rotation = Quaternion.LookRotation(test);

        anchor.transform.localRotation = Quaternion.Slerp(trying, anchor.rotation, Time.deltaTime);
        

        rb.AddForce(dir);
        */

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

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
