using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovingType
{
    PERSON = 1,
    TRAFFIC_LIGHT,
    OBJECT,
}

public class movingObject : MonoBehaviour {

    public MovingType type;


}
