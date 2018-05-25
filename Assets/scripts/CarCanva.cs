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

    void addObject(MovingType t)
    {
        if (displayedNb  + 1 > maxDisplay)
            return;
        displayedNb++;
        ImageObject[displayedNb - 1].SetActive(true);
        displayedType[displayedNb - 1] = t;
    }

    void removeObject(MovingType t)
    {
        if (displayedNb + 1 > maxDisplay)
            return;
        displayedNb++;
        ImageObject[displayedNb - 1].SetActive(true);
        displayedNb--;
    }

    // Update is called once per frame
	void Update () {
		
	}
}
