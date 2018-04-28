using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{

    public float turnSpeed = 4.0f;
    public Transform player;
    public GameObject anchor;
    private Vector3 vekkis;

    public float height = 1f;
    public float distance = 2f;

    private Vector3 offsetX;

    void Start()
    {

        offsetX = new Vector3(0, height, distance);
        
    }

    void LateUpdate()
    {

        transform.position = player.position + offsetX;
        transform.LookAt(player.position);
        
        if (Input.GetMouseButton(0))
        {
            offsetX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offsetX;
        }
    }
}