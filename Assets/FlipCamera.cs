using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCamera : MonoBehaviour
{
    public Animator cam;
    public bool canUseCamera;

    bool inFlipRange;

    bool flipedUp;
    bool mouseCheck;
    //3.5
    void Update()
    {
        float _mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float _mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

        float _mouseOffsetX = transform.position.x - _mouseX;
        float _mouseOffsetY = transform.position.y - _mouseY;

        if (Mathf.Abs(_mouseOffsetX) <= 3.5f && _mouseOffsetY >= 4.2f && canUseCamera)
        {
            if (!mouseCheck)
                flipedUp = !flipedUp;
            mouseCheck = true;
            UpdateCameraState();
        }
        else
        {
            mouseCheck = false;
        }
        Debug.Log(Mathf.Abs(_mouseOffsetX) + ")(" + _mouseOffsetY);
    }
    void UpdateCameraState()
    {
        if (flipedUp)
        {
            cam.SetBool("flipedUp", true);
        }
        else
        {
            cam.SetBool("flipedUp", false);
        }
    }
}