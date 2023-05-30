using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeManager : MonoBehaviour
{
    public GameManager gm;
    void Awake()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void Update()
    {
        
    }
}
