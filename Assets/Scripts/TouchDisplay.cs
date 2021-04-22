using UnityEngine;
using System.Collections;

public class TouchDisplay : MonoBehaviour
{
    void OnMouseDown()
    {
        Animator anim = this.GetComponent<Animator>();

        if (!anim.GetBool("Show"))
        {
            anim.ResetTrigger("Hide");
            anim.SetTrigger("Show");
        }
        else
        {
            anim.ResetTrigger("Show");
            anim.SetTrigger("Hide");
        }
    }
}