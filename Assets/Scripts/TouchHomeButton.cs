using UnityEngine;
using System.Collections;

public class TouchHomeButton : MonoBehaviour
{
    bool power = false;

    void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "Power":
                if (power) 
                {
                    power = false;
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                }
                else
                {
                    power = true;
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                break;
            case "My Space":
                break;
            case "Controls":
                break;
            case "Real Time":
                break;
            case "Stats":
                break;
        }
    }
}