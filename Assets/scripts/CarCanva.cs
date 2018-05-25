using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCanva : MonoBehaviour {

    public Sprite[] ImageSprite;
    public GameObject[] ImageObject;
    private uint displayedNb = 0;
    public const uint maxDisplay = 3;
    private MovingType[] displayedType = new MovingType[3];

	// Use this for initialization
	void Start () {
	    	
	}

    private int isIn(MovingType t, MovingType[] a)
    {
        int nbr = 0;
        foreach(MovingType x in a)
        {
            if (x == t)
                return nbr;
            nbr++;
        }
        return -1;
    }

    public void addObject(MovingType t)
    {
        int indexDisp = isIn(t, displayedType);
        if (displayedNb  + 1 > maxDisplay || !(indexDisp == -1))
            return;
        displayedNb++;
        ImageObject[displayedNb - 1].SetActive(true);
        displayedType[displayedNb - 1] = t;
    }

    public void removeObject(MovingType t)
    {
        int indexDisp = isIn(t, displayedType);
        if (displayedNb == 0 || indexDisp == -1)
            return;
        ImageObject[indexDisp].SetActive(false);
        displayedNb--;
    }

    // Update is called once per frame
	void Update () {
		
	}
}
