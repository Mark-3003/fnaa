using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Title : MonoBehaviour
{
    public GameObject fadeIn;

    public int gameScene;
    public float loadTimer;

    float timer;
    bool load;
    public void StartGame()
    {
        load = true;
        timer = Time.realtimeSinceStartup + loadTimer;
    }
    private void Update()
    {
        if (load)
        {
            fadeIn.SetActive(true);
            if (Time.realtimeSinceStartup > timer)
                SceneManager.LoadScene(gameScene);
        }
    }
}
