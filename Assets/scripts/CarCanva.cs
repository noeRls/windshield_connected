using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CarCanva : MonoBehaviour {

    public Sprite[] ImageSprite;
    public GameObject[] ImageObject;
    private int displayedNb = 0;
    public const int maxDisplay = 3;
    private List<MovingType> displayedType = new List<MovingType>();

    private void Start()
    {
        for (int i = 0; i < 3; i++)
            displayedType.Add(0);
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
        int indexDisp = displayedType.IndexOf(t);

        if (displayedNb  + 1 > maxDisplay || !(indexDisp == -1))
            return;
        displayedNb++;
        ImageObject[displayedNb - 1].SetActive(true);
        displayedType[displayedNb - 1] = t;
    }

    public void removeObject(MovingType t)
    {
        int indexDisp = displayedType.IndexOf(t);

        if (displayedNb == 0 || indexDisp == -1)
            return;
        ImageObject[displayedNb - 1].SetActive(false);
        for (int i = indexDisp; i < displayedType.Count - 1; i++)
        {
            displayedType[i] = displayedType[i + 1];
        }
        displayedNb--;
    }
}
