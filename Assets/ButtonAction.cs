using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    public bool toggleStatus;
    public string objectType;
    public void Toggle()
    {
        toggleStatus = !toggleStatus;
        DoSomething();
    }
    public bool ActionStatus()
    {
        return toggleStatus;
    }
    void DoSomething()
    {
        if(objectType == "Door")
        {
            GetComponent<SpriteRenderer>().enabled = toggleStatus;
        }
    }
}
