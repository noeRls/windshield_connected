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
    public List<float> timeToChange = new List<float>();
    float time = 0;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > timeToChange[(int) status])
        {
            status = (LightStatus) (((int) status + 1) % 3);
            time = 0;
        }
    }
}
