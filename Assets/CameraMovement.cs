using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Animator flipCam;

    public bool cameraFliped;
    public bool canTurn;
    public float turnSpeed = 1;
    public float moveLimit;
    public GameObject debugCeiling;
    public GameObject upperTrigger;

    public LayerMask mouseRayMask;

    GameManager gm;
    bool lookingUp;
    private void Awake()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void Update()
    {
        cameraFliped = flipCam.GetBool("flipedUp");

        if(Input.GetMouseButtonDown(0))
            sendMouseRay();

        float _mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float _mouseOffsetX = transform.position.x - _mouseX;

        if (Mathf.Abs(_mouseOffsetX) >= 5.4f && canTurn && !cameraFliped)
        {
            float _Movementdirection = _mouseOffsetX / Mathf.Abs(_mouseOffsetX);
            float _mouseDelta = (Mathf.Abs(_mouseOffsetX) - 5.4f) / 2;

            transform.position = new Vector3(Mathf.Clamp(transform.position.x - Mathf.Clamp(turnSpeed * _mouseDelta, 0, turnSpeed * 1.5f) * _Movementdirection * Time.deltaTime, -moveLimit, moveLimit), 0, -10);
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
    void sendMouseRay()
    {
        //Debug.Log("Mouse click detected");

        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = -10f;

        RaycastHit hit;
        Physics.Raycast(_mousePos, Vector3.forward, out hit, Mathf.Infinity, mouseRayMask);

        if(hit.collider != null)
        {
            if (hit.collider.GetComponent<CameraButton>())
            {
                hit.collider.GetComponent<CameraButton>().ClickedOn();
            }
            Debug.Log("HIT: " + hit.collider.name);
        }
    }
    void CheckCeiling(bool _lookUp)
    {
        if (_lookUp)
        {
            gm.PlayerLookingAt("ceiling");
            GetComponent<FlipCamera>().UpdateCameraState(true);
            debugCeiling.SetActive(true);
            upperTrigger.SetActive(false);
            lookingUp = true;
        }
        else
        {
            gm.PlayerLookingAt("forward");
            GetComponent<FlipCamera>().cameraUseDelay(0.5f);
            debugCeiling.SetActive(false);
            upperTrigger.SetActive(true);
            lookingUp = false;
        }
    }
}
