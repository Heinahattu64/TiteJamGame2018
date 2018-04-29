using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnchor : MonoBehaviour {

    public Transform player;
    public Transform camMain;
    public float rotaterate;
    public float x;
    public float z;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 test = camMain.position;
        Quaternion camRotation = camMain.localRotation;
        //anchor.rotation = Quaternion.LookRotation(test);

        transform.localRotation = Quaternion.Slerp(camRotation, transform.rotation, Time.deltaTime);
    }

    public void LateUpdate()
    {
        transform.position = player.transform.position;
    }
}
