using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    int z = 15;
    int y = 15;

    private int buildingPerRoad = 2;

    public float crazyRate = 0.5f;
    public float trafficLightRate = 0.5f;
    public GameObject trafficLightGO;
    public GameObject cross;
    public GameObject building;
    public GameObject sider;
    public GameObject pedistrian;
    public GameObject road;
    public float roadSize = 8f;

// Use this for initialization
void Start () {
        for (int i = 0; i < z; i++)
        {
            if (i % buildingPerRoad == 0)
                Instantiate(building, new Vector3(0, 0, transform.position.z + (i * roadSize)), Quaternion.identity);
            if (Random.Range(0f, 1f) < (crazyRate / z))
                Instantiate(pedistrian, new Vector3(0, 0, transform.position.z + (i * roadSize)), Quaternion.identity);
            if (Random.Range(0f, 1f) < (trafficLightRate / z))
            {
                Instantiate(trafficLightGO, new Vector3(0, 0, transform.position.z + (i * roadSize)), Quaternion.identity);
                Instantiate(cross, new Vector3(0, 0, transform.position.z + (i * roadSize)), Quaternion.identity);
                Instantiate(pedistrian, new Vector3(0, 0, transform.position.z + (i * roadSize)), Quaternion.identity);
            }
            else
            {
                Instantiate(road, new Vector3(0, 0, transform.position.z + (i * roadSize)), Quaternion.identity);
            }
        }
	}
}
