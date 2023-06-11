using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    public int gameScene;

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }
}
