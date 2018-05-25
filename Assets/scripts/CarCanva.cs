using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CarCanva : MonoBehaviour {

    public Sprite[] ImageSprite;
    public GameObject[] ImageObject;
    private int displayedNb = 0;
    public const int maxDisplay = 3;
    private List<MovingType> displayedType = new List<MovingType>();
    private List<Image> imgUi = new List<Image>();

    private void Start()
    {
        for (int i = 0; i < 4; i++)
            displayedType.Add(MovingType.NOTHING);
        for (int i = 0; i < maxDisplay; i++)
        {
            imgUi.Add(ImageObject[i].GetComponent<Image>());
        }
    }

    private void updateImages()
    {
        for (int i = 0; i < displayedNb; i++)
        {
            imgUi[i].sprite = ImageSprite[(int) displayedType[i] - 1];
        }
    }

    public void addObject(MovingType t)
    {
        int indexDisp = displayedType.IndexOf(t);

        Debug.Log(displayedNb + 1 > maxDisplay);
        Debug.Log(indexDisp);
        if (displayedNb  + 1 > maxDisplay || indexDisp != -1)
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
