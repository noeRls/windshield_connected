using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Car : MonoBehaviour {

    public float speed = 0;
    public float maxSpeed = 0;
    public float brakeForce = 0;
    public float accelerateForce = 0;
    public List<movingObject> objects = new List<movingObject>();
    private AudioSource aus;
    public GameObject WarnLights;
    public GameObject SafeLights;
    public float WarnTime;

    private GameObject lastKlaxoned;

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

        if (objects.Count == 0)
            return null;
        foreach (var i in objects)
        {
            tmp = Vector3.Distance(i.transform.position, transform.position);
            if (tmp < min)
            {
                min = tmp;
                closest = i.gameObject;
            }
        }
        return closest;
    }

    IEnumerator AnimWarn()
    {
        cc.setState(State.STOP);
        aus.Play();
        WarnLights.SetActive(true);
        yield return new WaitForSeconds(WarnTime);
        WarnLights.SetActive(false);
        cc.setState(State.NOTHING);
    }

    public void Warn()
    {
        StartCoroutine(AnimWarn());
    }

    private void UpdateTrafficLights()
    {
        foreach(var i in objects)
        {
            if (i.type == MovingType.TRAFFIC_LIGHT && !i.toDisplay())
            {
                objects.Remove(i);
                break;
            }
        }
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
        if (dist < 15f)
        {
            decelerate = true;
            speed = Mathf.Lerp(speed, 0, brakeForce * (15f / dist) * Time.deltaTime);
        }
        else
        {
            speed = Mathf.Lerp(speed, maxSpeed, accelerateForce * Time.deltaTime);
        }
        if (speed < 0.05 && decelerate)
            speed = 0;
        if (closest && !objects.Any(s => s.type == MovingType.TRAFFIC_LIGHT) && dist < 15.0f && lastKlaxoned != closest)
        {
            lastKlaxoned = closest;
            Warn();
        }
        transform.position += transform.forward * speed * Time.deltaTime;
        SafeLights.SetActive(speed < 1 && objects.Any(s => s.type == MovingType.TRAFFIC_LIGHT));
        cc.setContent(objects.Count != 0);
        UpdateTrafficLights();
    }

    private void OnTriggerEnter(Collider other)
    {
        movingObject obj;

        if (!other.gameObject.CompareTag("Moving"))
            return;
        obj = other.gameObject.GetComponent<movingObject>();
        objects.Add(obj);
    }

    private void OnTriggerExit(Collider other)
    {
        movingObject obj;

        if (!other.gameObject.CompareTag("Moving"))
            return;
        obj = other.gameObject.GetComponent<movingObject>();
        objects.Remove(obj);
    }
}
