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
    float cameraWait;

    GameManager gm;
    //3.5
    private void Awake()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        cameraWait = 0;
    }
    void Update()
    {
        if (Time.realtimeSinceStartup >= cameraWait)
            canUseCamera = true;

        float _mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float _mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

        float _mouseOffsetX = transform.position.x - _mouseX;
        float _mouseOffsetY = transform.position.y - _mouseY;

        if (Mathf.Abs(_mouseOffsetX) <= 3.5f && _mouseOffsetY >= 4.2f && canUseCamera && gm.getLookDirection() == "forward")
        {
            if (!mouseCheck)
                flipedUp = !flipedUp;
            mouseCheck = true;
            UpdateCameraState(false);
        }
        else
        {
            mouseCheck = false;
        }
    }
    public void UpdateCameraState(bool _forceFlipDown)
    {
        if (_forceFlipDown)
        {
            cam.SetBool("flipedUp", false);
        }
        else
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
    public void cameraUseDelay(float _waitTime)
    {
        cameraWait = Time.realtimeSinceStartup + _waitTime;
        canUseCamera = false;
    }
}