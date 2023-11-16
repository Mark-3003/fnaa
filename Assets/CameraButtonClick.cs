using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButtonClick : MonoBehaviour
{
    public int cameraID;
    public Vector2 selectionSize;
    EnemyManager em;
    private void Start()
    {
        em = GameObject.Find("GameManager").GetComponent<EnemyManager>();
    }
    public void ClickedOn()
    {
        em.SetActiveCamera(cameraID, gameObject, selectionSize);
    }
}
