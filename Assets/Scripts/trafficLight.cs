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
    public bool isRandom = true;
    float time = 0;

    private void Start()
    {
        if (isRandom)
        {
            status = (LightStatus) Random.Range(0, 2);
            time = Random.Range(0, timeToChange[(int) status]);
        }
    }

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
