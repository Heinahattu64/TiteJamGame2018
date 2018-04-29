using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnchor : MonoBehaviour {

    public Transform player;
    public Transform camMain;
    public float rotaterate;
    public float x;
    public float z;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent <Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 test = camMain.position;
        Quaternion camRotation = camMain.localRotation;
        //anchor.rotation = Quaternion.LookRotation(test);

        transform.localRotation = Quaternion.Slerp(camRotation, transform.rotation, Time.deltaTime);
    }

    public void MovementTry()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * rotaterate;
        z = Input.GetAxis("Vertical") * Time.deltaTime * rotaterate;
    }

    public void LateUpdate()
    {
        transform.position = player.transform.position;
    }
}
