using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smartCam : MonoBehaviour {

    private GameObject toFollow;
    public float height;
    public List<GameObject> listObjects = new List<GameObject>();
    private int index = 0;

    public void next()
    {
        toFollow = listObjects[index++];
    }

    private void Update()
    {
        if (toFollow)
        {
            transform.rotation = toFollow.transform.rotation;
            if (Vector3.Distance(transform.position, toFollow.transform.position) < 2.0f)
            {
                transform.position = Vector3.Lerp(transform.position, toFollow.transform.position + new Vector3(0, height, 0), 15.0f * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, toFollow.transform.position + new Vector3(0, height, 0), 5.0f * Time.deltaTime);
            }
        }
    }

}
