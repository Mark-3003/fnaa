using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform selectionYellow;
    public int currentActiveCamera;
    public void SetActiveCamera(int _cameraID, GameObject _obj, Vector2 _size)
    {
        selectionYellow.SetParent(_obj.transform);
        selectionYellow.position = Vector2.zero;
        selectionYellow.localScale = _size;

        currentActiveCamera = _cameraID;
    }
}
