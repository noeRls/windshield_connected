using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightStatus
{
    GREEN,
    ORANGE,
    RED
}

public class trafficLight : MonoBehaviour {

    public LightStatus status;
    public float timeToChange = 10;
    float time = 0;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > timeToChange)
        {
            status = (LightStatus) (((int) status + 1) % 3);
            time = 0;
        }
    }
}
