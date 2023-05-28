using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool canTurn;
    public float turnSpeed = 1;
    public float moveLimit;
    public GameObject debugCeiling;

    GameManager gm;
    bool lookingUp;
    private void Awake()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void Update()
    {
        float _mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float _mouseOffsetX = transform.position.x - _mouseX;

        if (Mathf.Abs(_mouseOffsetX) >= 5.4f && canTurn)
        {
            float _Movementdirection = _mouseOffsetX / Mathf.Abs(_mouseOffsetX);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x - turnSpeed * _Movementdirection * Time.deltaTime, -moveLimit, moveLimit), 0, -10);
        }
        // DEBUG EXIT
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        float _mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

        float _mouseOffsetY = transform.position.y - _mouseY;

        if (Mathf.Abs(_mouseOffsetX) <= 3.5f && _mouseOffsetY <= -4.2f && !lookingUp)
        {
            Debug.Log("Looked Up");
            CheckCeiling(true);
        }
        else if(Mathf.Abs(_mouseOffsetX) <= 3.5f && _mouseOffsetY >= 4.2f && lookingUp)
        {
            Debug.Log("Looked Down");
            CheckCeiling(false);
        }
    }
    void CheckCeiling(bool _lookUp)
    {
        if (_lookUp)
        {
            gm.PlayerLookingAt("ceiling");
            GetComponent<FlipCamera>().UpdateCameraState(true);
            debugCeiling.SetActive(true);
            lookingUp = true;
        }
        else
        {
            gm.PlayerLookingAt("forward");
            GetComponent<FlipCamera>().cameraUseDelay(0.7f);
            debugCeiling.SetActive(false);
            lookingUp = false;
        }
    }
}
