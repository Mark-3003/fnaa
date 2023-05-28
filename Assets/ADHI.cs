using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADHI : MonoBehaviour
{
    public float moveSpeed = 5;
    public int AIlevel;
    public GameManager gm;

    public bool DEBUGbutton;

    string currentRoom;
    int currentProgression;
    float timer;
    private void Awake()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        initializeEnemy(gm.currentNight);
    }
    private void Update()
    {
        if (DEBUGbutton)
        {
            DEBUGbutton = false;

            currentRoom = "mainStartArea";
            gm.moveEnemyTo("ADHI", currentRoom, 1);
            currentProgression = 1;
        }
        if(Time.realtimeSinceStartup >= timer)
        {
            timer = Time.realtimeSinceStartup + (moveSpeed - (Time.realtimeSinceStartup - timer));
            moveChance();
        }
    }
    void moveChance()
    {
        int _randomNumber = Random.Range(1, 20);

        if(_randomNumber <= AIlevel)
        {
            move();
        }
    }
    void move()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int _chance;

        if(currentRoom == "mainStartArea")
        {
            currentRoom = "generalArea1";
            gm.moveEnemyTo("ADHI", currentRoom, 1);
            currentProgression = 1;
        }
        else if (currentRoom == "generalArea1")
        {
            currentRoom = "mainHall1";
            gm.moveEnemyTo("ADHI", currentRoom, 1);
            currentProgression = 1;
        }
        else if (currentRoom == "mainHall1")
        {
            if(currentProgression == 1)
            {
                currentRoom = "mainHall1";
                gm.moveEnemyTo("ADHI", currentRoom, 2);
                currentProgression = 2;
            }
            else
            {
                _chance = Random.Range(1, 10);
                if (_chance <= 5)
                {
                    currentRoom = "office";
                    gm.moveEnemyTo("ADHI", currentRoom, 1);
                    currentProgression = 1;
                }
                else
                {
                    currentRoom = "sideHall";
                    gm.moveEnemyTo("ADHI", currentRoom, 1);
                    currentProgression = 1;
                }
            }
        }
        else if (currentRoom == "sideHall")
        {
            if (currentProgression == 1)
            {
                currentRoom = "sideHall";
                gm.moveEnemyTo("ADHI", currentRoom, 2);
                currentProgression = 2;
            }
            else if(currentProgression == 2)
            {
                _chance = Random.Range(1, 10);
                if(_chance <= 5)
                {
                    currentRoom = "storageRoom";
                    gm.moveEnemyTo("ADHI", currentRoom, 1);
                    currentProgression = 1;
                }
                else
                {
                    currentRoom = "sideHall";
                    gm.moveEnemyTo("ADHI", currentRoom, 3);
                    currentProgression = 3;
                }
            }
            else
            {
                // GAME OVER
                currentRoom = "mainStartArea";
                gm.moveEnemyTo("ADHI", currentRoom, 1);
                currentProgression = 1;
            }
        }
        else if (currentRoom == "storageRoom")
        {
            currentRoom = "sideHall";
            gm.moveEnemyTo("ADHI", currentRoom, 2);
            currentProgression = 2;
        }
        else if (currentRoom == "office")
        {
            if(currentProgression == 1)
            {
                currentRoom = "office";
                gm.moveEnemyTo("ADHI", currentRoom, 2);
                currentProgression = 2;
            }
            else
            {
                // GAME OVER
                currentRoom = "mainStartArea";
                gm.moveEnemyTo("ADHI", currentRoom, 1);
                currentProgression = 1;
            }
        }
    }
    void initializeEnemy(int _night)
    {
        timer = Time.realtimeSinceStartup + moveSpeed;
        gm.adhi = this;

        switch (_night)
        {
            case 1:
                AIlevel = 2;
                break;
            case 2:
                AIlevel = 2;
                break;
            case 3:
                AIlevel = 2;
                break;
            case 4:
                AIlevel = 2;
                break;
            case 5:
                AIlevel = 2;
                break;
            case 6:
                AIlevel = 2;
                break;
            case 7:
                AIlevel = 20;
                break;
            default:
                AIlevel = 20;
                break;
        }
        currentRoom = "mainStartArea";
        gm.moveEnemyTo("ADHI", currentRoom, 1);
    }
    public void changeAILevel(int _change)
    {
        AIlevel += _change;
    }
}
