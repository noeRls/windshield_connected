using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObjectTrafficLight : movingObject {

    private trafficLight tl;

    private void Start()
    {
        tl = GetComponent<trafficLight>();
    }

    public override bool toDisplay()
    {
        return (tl.status != LightStatus.GREEN);
    }
}
