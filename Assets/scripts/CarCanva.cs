using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public enum State
{
    NOTHING,
    PASS,
    STOP
}

public class CarCanva : MonoBehaviour {

    public Sprite[] stateSprite;
    public GameObject stateObj;
    public GameObject contentObj;
    private Image stateImg;
    private Image contentImg;

    private void Start()
    {
        stateImg = stateObj.GetComponent<Image>();
        contentImg = contentObj.GetComponent<Image>();
    }

    public void setContent(bool p)
    {
        contentObj.SetActive(p);
    }

    public void setState(State s)
    {
        if ((int) s == 0)
        {
            stateObj.SetActive(false);
        }
        else
        {
            stateObj.SetActive(true);
        }
        stateImg.sprite = stateSprite[(int) s];
    }
}
