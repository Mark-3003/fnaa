using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool canTurn;
    public float turnSpeed = 1;
    void Update()
    {
        float _mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float _mouseOffset = Camera.main.transform.position.x - _mouseX;

        if (Mathf.Abs(_mouseOffset) >= 5.4f && canTurn)
        {
            float _Movementdirection = _mouseOffset / Mathf.Abs(_mouseOffset);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x - turnSpeed * _Movementdirection * Time.deltaTime, -9.5f, 9.5f), 0, -10);
        }
        // 5.4
    }
}
