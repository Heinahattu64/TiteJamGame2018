using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnchor : MonoBehaviour {

    public Transform player;
    public Transform camMain;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
        transform.rotation = camMain.transform.rotation;
	}
}
