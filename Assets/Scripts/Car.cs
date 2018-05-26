﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Car : MonoBehaviour {

    public float speed = 0;
    public float maxSpeed = 0;
    public float brakeForce = 0;
    public float accelerateForce = 0;
    public List<movingObject> objects = new List<movingObject>();
    public List<GameObject> gameObjects = new List<GameObject>();
    private AudioSource aus;
    public GameObject WarnLights;
    public GameObject SafeLights;
    public float WarnTime;

    private CarCanva cc;

    private void Start()
    {
        aus = GetComponent<AudioSource>();
        cc = GetComponent<CarCanva>();
    }

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

    IEnumerator AnimWarn()
    {
        aus.Play();
        WarnLights.SetActive(true);
        yield return new WaitForSeconds(WarnTime);
        WarnLights.SetActive(false);
    }

    public void Warn()
    {
        StartCoroutine(AnimWarn());
    }

    private void Update()
    {
        GameObject closest = getClosest();
        float dist = 800;
        bool decelerate = false;

        if (closest)
        {
            dist = Vector3.Distance(closest.transform.position, transform.position);
        }
        if (dist < 12.5)
        {
            decelerate = true;
            speed = Mathf.Lerp(speed, 0, brakeForce * (10.0f - dist) * Time.deltaTime);
        }
        else
        {
            speed = Mathf.Lerp(speed, maxSpeed, accelerateForce * Time.deltaTime);
        }
        if (speed < 0.05 && decelerate)
            speed = 0;
        if (closest && !objects.Any(s => s.type == MovingType.TRAFFIC_LIGHT) && dist < 15.0f)
        {
            Warn();
        }
        transform.position += transform.forward * speed * Time.deltaTime;
        SafeLights.SetActive(speed < 1 && objects.Any(s => s.type == MovingType.TRAFFIC_LIGHT));
    }

    private void OnTriggerEnter(Collider other)
    {
        movingObject obj;
        Debug.Log("Adding");
        if (!other.gameObject.CompareTag("Moving"))
            return;
        obj = other.gameObject.GetComponent<movingObject>();
        if (obj && obj.toDisplay())
        {
            objects.Add(obj);
            cc.addObject(obj.type);
            gameObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        movingObject obj;

        if (!other.gameObject.CompareTag("Moving"))
            return;
        obj = other.gameObject.GetComponent<movingObject>();
        if (objects.Find(s => s == obj) && !obj.toDisplay())
        {
            objects.Remove(obj);
            cc.removeObject(obj.type);
            gameObjects.Remove(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        movingObject obj;

        if (!other.gameObject.CompareTag("Moving"))
            return;
        obj = other.gameObject.GetComponent<movingObject>();
        objects.Remove(obj);
        cc.removeObject(obj.type);
        gameObjects.Remove(other.gameObject);
    }
}
