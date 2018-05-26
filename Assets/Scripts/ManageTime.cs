using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageTime : MonoBehaviour {

    private bool paused = false;

    private void Update()
    {
        bool pause = Input.GetKeyDown(KeyCode.Space);

        if (!paused && pause)
        {
            paused = true;
            Time.timeScale = 0;
        }
        else if (paused && pause)
        {
            paused = false;
            Time.timeScale = 1;
        }
    }

}
