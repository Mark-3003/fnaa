using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideButtons : MonoBehaviour
{
    public ButtonAction action;

    [Header("Colours")]
    public Color onColor;
    public Color offColor;
    public void ButtonTrigger()
    {
        action.Toggle();
        if (action.toggleStatus)
        {
            GetComponent<SpriteRenderer>().color = onColor;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = offColor;
        }
    }
    void Awake()
    {
        GetComponent<SpriteRenderer>().color = offColor;
    }
}
