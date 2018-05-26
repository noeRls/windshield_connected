using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMan : MonoBehaviour {

    private GameObject taxi;
    private bool began;
    private float distToGo;
    private float walkingSpeed;

    private void Start()
    {
        taxi = GameObject.Find("Taxi");
        distToGo = Random.Range(15, 35);
        walkingSpeed = Random.Range(2, 8);
    }

    private void Update()
    {
        if (!began && Vector3.Distance(transform.position, taxi.transform.position) < distToGo)
        {
            began = true;
        }
        if (!began)
            return;
        transform.position += transform.forward * walkingSpeed * Time.deltaTime;
    }
}
