using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovingType
{
    NOTHING = 0,
    PERSON,
    TRAFFIC_LIGHT,
    OBJECT,
}

public class movingObject : MonoBehaviour {

    public MovingType type;

    public virtual bool toDisplay()
    {
        return true;
    }
}
