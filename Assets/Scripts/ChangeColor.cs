using UnityEngine;
using System.Collections;
using TMPro;

public class ChangeColor : MonoBehaviour
{
    bool alert = false;
    public GameObject meshObject, alertObject;
    public TextMeshPro textObject;
    int x = 0;
    private void Update()
    {
        if(x == 30)
        {
            textObject.text = "" + Random.Range(0, 99);
            x = 0;
        }
        if (int.Parse(textObject.text) >= 50)
            alert = true;
        else
            alert = false;

        if (alert)
        {
            alertObject.SetActive(true);
            meshObject.SetActive(false);
        }
        else
        {
            meshObject.SetActive(true);
            alertObject.SetActive(false);
        }
        x++;
    }
}