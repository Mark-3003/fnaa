using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraButton : MonoBehaviour
{
    public GameManager gm;
    public TMP_Text text;
    public int camNumber;

    public Color normalColor;
    public Color toggleColor;

    [Header("Camera Image")]
    public GameObject img;
    [Header("EnemyImages")]
    public GameObject adhi;
    public GameObject adhi2;
    public GameObject bemu;
    public GameObject bemu2;
    public GameObject wich;
    public GameObject wich2;
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
        CheckCharacters();

        text.text = "Cam" + camNumber.ToString();
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
    void CheckCharacters()
    {
        if (adhi != null)
        {
            int _adhi = gm.returnCharacter(img.name, "ADHI");
            if (_adhi == 1)
            {
                adhi.SetActive(true);
            }
            else if (_adhi == 2)
            {
                adhi2.SetActive(true);
            }
            else
            {
                adhi.SetActive(false);
                adhi2.SetActive(false);
            }
        }

        if (bemu != null)
        {
            int _bemu = gm.returnCharacter(img.name, "BEMU");
            if (_bemu == 1)
            {
                bemu.SetActive(true);
            }
            else if (_bemu == 2)
            {
                bemu2.SetActive(true);
            }
            else
            {
                bemu.SetActive(false);
                bemu2.SetActive(false);
            }
        }

        if (wich != null)
        {
            int _wich = gm.returnCharacter(img.name, "WICH");
            if (_wich == 1)
            {
                wich.SetActive(true);
            }
            else if (_wich == 2)
            {
                wich2.SetActive(true);
            }
            else
            {
                wich.SetActive(false);
                wich2.SetActive(false);
            }
        }
    }
}
