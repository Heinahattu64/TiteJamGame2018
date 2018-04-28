using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    public GameObject player;
    public GameObject camFind;
    private Vector3 offset;


	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position; 
	}

    void Update()
    {
        MoveCamera();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
    }

    void MoveCamera()
    {
        if (Input.GetMouseButton(0))
        {

        }
    }
}
