using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smartCam : MonoBehaviour {

    public GameObject toFollow;
    public float height;

    private void Update()
    {
        if (toFollow)
        {
            transform.rotation = toFollow.transform.rotation;
            if (Vector3.Distance(transform.position, toFollow.transform.position) < 1)
            {
                transform.position = Vector3.Lerp(transform.position, toFollow.transform.position + new Vector3(0, height, 0), 10.0f * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, toFollow.transform.position + new Vector3(0, height, 0), 5.0f * Time.deltaTime);
            }
        }
    }

}
