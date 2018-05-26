using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextTarget : MonoBehaviour {

    private smartCam cam;
    private Car c;

    private void Start()
    {
        c = GameObject.Find("Taxi").GetComponent<Car>();
        cam = GetComponentInChildren<smartCam>();
    }

    public void next()
    {
        cam.next();
    }

    public void Warn()
    {
        c.Warn();
    }
}
