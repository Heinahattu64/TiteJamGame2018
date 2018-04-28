using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propellerRotate : MonoBehaviour {

    public float propellerRate;
    public Vector3 propellerDirection;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate((propellerDirection * propellerRate) * Time.deltaTime);

	}
}
