using UnityEngine;
using System.Collections;

public class TouchToExpand : MonoBehaviour
{
    bool expand = false;
    public GameObject expandObject;

    void OnMouseDown()
    {
        if (!expand)
        {
            expandObject.SetActive(true);
            expand = true;
        }
        else
        {
            expandObject.SetActive(false);
            expand = false;
        }
    }
}