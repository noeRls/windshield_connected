﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Car : MonoBehaviour {

    public float speed = 0;
    public float maxSpeed = 0;
    public float brakeForce = 0;
    public float accelerateForce = 0;
    public List<MovingType> objects = new List<MovingType>();
    public List<GameObject> gameObjects = new List<GameObject>();

    GameObject getClosest()
    {
        GameObject closest = null;
        float min = 10;
        float tmp = 0;

        if (gameObjects.Count == 0)
            return null;
        foreach (var i in gameObjects)
        {
            tmp = Vector3.Distance(i.transform.position, transform.position);
            if (tmp < min)
            {
                min = tmp;
                closest = i;
            }
        }
        return closest;
    }

    private void Update()
    {
        GameObject closest = getClosest();
        float dist = 8;
        bool decelerate = false;

        if (closest)
        {
            Debug.Log(closest.GetComponent<movingObject>().type);
            dist = Vector3.Distance(closest.transform.position, transform.position);
        }
        if (dist < 7.5)
        {
            Debug.Log("Decelerate");
            decelerate = true;
            speed = Mathf.Lerp(speed, 0, brakeForce * Time.deltaTime);
        }
        else
        {
            speed = Mathf.Lerp(speed, maxSpeed, accelerateForce * Time.deltaTime);
        }
        if (speed < 0.05 && decelerate)
            speed = 0;
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Moving"))
            return;
        objects.Add(other.gameObject.GetComponent<movingObject>().type);
        gameObjects.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Moving"))
            return;
        objects.Remove(other.gameObject.GetComponent<movingObject>().type);
        gameObjects.Remove(other.gameObject);
    }
}