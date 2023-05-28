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
            gm.moveEnemyTo("ADHI", "mainStartArea", 1);
            currentRoom = "mainStartArea";
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
            gm.moveEnemyTo("ADHI", "generalArea1", 1);
            currentRoom = "generalArea1";
            currentProgression = 1;
        }
        else if (currentRoom == "generalArea1")
        {
            gm.moveEnemyTo("ADHI", "mainHall1", 1);
            currentRoom = "mainHall1";
            currentProgression = 1;
        }
        else if (currentRoom == "mainHall1")
        {
            if(currentProgression == 1)
            {
                gm.moveEnemyTo("ADHI", "mainHall1", 2);
                currentRoom = "mainHall1";
                currentProgression = 2;
            }
            else
            {
                _chance = Random.Range(1, 10);
                if (_chance <= 5)
                {
                    gm.moveEnemyTo("ADHI", "office", 1);
                    currentRoom = "office";
                    currentProgression = 1;
                }
                else
                {
                    gm.moveEnemyTo("ADHI", "sideHall", 1);
                    currentRoom = "sideHall";
                    currentProgression = 1;
                }
            }
        }
        else if (currentRoom == "sideHall")
        {
            if (currentProgression == 1)
            {
                gm.moveEnemyTo("ADHI", "sideHall", 2);
                currentRoom = "sideHall";
                currentProgression = 2;
            }
            else if(currentProgression == 2)
            {
                _chance = Random.Range(1, 10);
                if(_chance <= 5)
                {
                    gm.moveEnemyTo("ADHI", "storageRoom", 1);
                    currentRoom = "storageRoom";
                    currentProgression = 1;
                }
                else
                {
                    gm.moveEnemyTo("ADHI", "sideHall", 3);
                    currentRoom = "sideHall";
                    currentProgression = 3;
                }
            }
            else
            {
                // GAME OVER
                gm.moveEnemyTo("ADHI", "mainStartArea", 1);
                currentRoom = "mainStartArea";
                currentProgression = 1;
            }
        }
        else if (currentRoom == "storageRoom")
        {
            gm.moveEnemyTo("ADHI", "sideHall", 2);
            currentRoom = "sideHall";
            currentProgression = 2;
        }
        else if (currentRoom == "office")
        {
            if(currentProgression == 1)
            {
                gm.moveEnemyTo("ADHI", "office", 2);
                currentRoom = "office";
                currentProgression = 2;
            }
            else
            {
                // GAME OVER
                gm.moveEnemyTo("ADHI", "mainStartArea", 1);
                currentRoom = "mainStartArea";
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
        gm.moveEnemyTo("ADHI", "mainStartArea", 1);
        currentRoom = "mainStartArea";
    }
    public void changeAILevel(int _change)
    {
        AIlevel += _change;
    }
}
