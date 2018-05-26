using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayLightCycle : MonoBehaviour {

    private Light light;
    public float dayLength;
    public float maxIntens;

    private float currentTime;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        float perc = currentTime / dayLength;

        if (currentTime > dayLength)
        {
            currentTime = 0;
        }
        currentTime += Time.deltaTime;
        light.intensity = Mathf.Abs(0.5f - perc);
    }
}
