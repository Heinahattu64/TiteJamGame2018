using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobbyFollow : MonoBehaviour {

    public Transform center;
    private Rigidbody rb;
    public GameObject player;

    public float thrust;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
      
        transform.LookAt(center);
        rb.AddRelativeForce(Vector3.forward * thrust);

   
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        Debug.Log(distance);
        if (distance > 2)
            
            tpToPlayer();

	}

    void tpToPlayer()
    {
        Vector3 centerPos = player.transform.position;
        Vector3 temp = new Vector3(0f, 0.5f, 0f);
        centerPos += temp;

        gameObject.transform.position = centerPos;
    }

}