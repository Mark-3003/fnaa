using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButton : MonoBehaviour
{
    public GameManager gm;

    public Color normalColor;
    public Color toggleColor;

    [Header("Camera Image")]
    public GameObject img;
    void Awake()
    {
        img.SetActive(false);
        GetComponent<SpriteRenderer>().color = normalColor;
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    public void ClickedOn()
    {
        gm.setCurrentRoom(this);
        img.SetActive(true);

        GetComponent<SpriteRenderer>().color = toggleColor;
    }
    public void Restart()
    {
        GetComponent<SpriteRenderer>().color = normalColor;
        img.SetActive(false);
    }
    public void BootUp()
    {
        GetComponent<SpriteRenderer>().color = toggleColor;
        img.SetActive(true);
    }
}
