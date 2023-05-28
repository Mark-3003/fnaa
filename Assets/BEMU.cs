using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEMU : MonoBehaviour
{
    public float moveSpeed = 5;
    public int AIlevel;
    public int originalAIlevel;
    public GameManager gm;

    public bool dash;
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

            currentRoom = "sneakstersStart";
            currentProgression = 1;
            gm.moveEnemyTo("BEMU", currentRoom, currentProgression);
        }
        if (Time.realtimeSinceStartup >= timer)
        {
            timer = Time.realtimeSinceStartup + (moveSpeed - (Time.realtimeSinceStartup - timer));
            moveChance();
        }
    }
    void moveChance()
    {
        int _randomNumber = Random.Range(1, 20);

        if (_randomNumber <= AIlevel)
        {
            move();
        }
    }
    void Restart()
    {
        AIlevel = originalAIlevel;
        dash = false;

        currentRoom = "sneakstersStart";
        currentProgression = 1;
        gm.moveEnemyTo("BEMU", currentRoom, currentProgression);
    }
    void move()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        int _chance;

        if (currentRoom == "sneakstersStart")
        {
            if (currentProgression == 1)
            {
                currentRoom = "sneakstersStart";
                currentProgression = 2;
                gm.moveEnemyTo("BEMU", currentRoom, currentProgression);
            }
            else if(currentProgression == 2)
            {
                currentRoom = "sneakstersStart";
                currentProgression = 3;
                gm.moveEnemyTo("BEMU", currentRoom, currentProgression);
            }
            else
            {
                currentRoom = "generalArea1";
                currentProgression = 1;
                gm.moveEnemyTo("BEMU", currentRoom, currentProgression);
            }
        }
        else if(currentRoom == "generalArea1")
        {
            if(currentProgression == 1)
            {
                currentRoom = "generalArea1";
                currentProgression = 2;
                gm.moveEnemyTo("BEMU", currentRoom, currentProgression);
            }
            else if(currentProgression == 2 && !dash)
            {
                currentRoom = "generator";
                currentProgression = 1;
                gm.moveEnemyTo("BEMU", currentRoom, currentProgression);
            }
            else if(currentProgression == 2 && dash)
            {
                currentRoom = "mainHall1";
                currentProgression = 1;
                gm.moveEnemyTo("BEMU", currentRoom, currentProgression);
            }
        }
        else if(currentRoom == "generator")
        {
            if (currentProgression == 1)
            {
                currentRoom = "generator";
                currentProgression = 2;
                gm.moveEnemyTo("BEMU", currentRoom, currentProgression);
            }
            else
            {
                currentRoom = "generalArea1";
                currentProgression = 1;
                gm.moveEnemyTo("BEMU", currentRoom, currentProgression);
                AIlevel += 10;
                dash = true;
            }
        }
    }
    void initializeEnemy(int _night)
    {
        timer = Time.realtimeSinceStartup + moveSpeed;
        gm.bemu = this;

        switch (_night)
        {
            case 1:
                originalAIlevel = 2;
                break;
            case 2:
                originalAIlevel = 2;
                break;
            case 3:
                originalAIlevel = 2;
                break;
            case 4:
                originalAIlevel = 2;
                break;
            case 5:
                originalAIlevel = 2;
                break;
            case 6:
                originalAIlevel = 2;
                break;
            case 7:
                originalAIlevel = 20;
                break;
            default:
                originalAIlevel = 20;
                break;
        }
        Restart();
    }
    public void changeAILevel(int _change)
    {
        AIlevel += _change;
    }
}
