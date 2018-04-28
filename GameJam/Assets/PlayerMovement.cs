using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float rotaterate;
    private Rigidbody rb;

    public float jumpPower;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        MoveBlobby();
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
}
