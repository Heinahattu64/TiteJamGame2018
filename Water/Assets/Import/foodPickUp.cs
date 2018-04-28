using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodPickUp : MonoBehaviour {

    public GameObject player;
    public int foodmeter;

    void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);
        foodmeter += 1;
    }

    void FoodSystem()
    {

    }
}
