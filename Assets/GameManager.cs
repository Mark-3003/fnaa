using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentNight;
    public int currentDisplayedTime;

    public AudioSource audioSource;
    public AudioClip[] soundEffects;

    [Header("Enemies")]
    public ADHI adhi;
    public BEMU bemu;

    [Header("CameraButtons")]
    public CameraButton mainStartAreaButton;
    public CameraButton generalArea1Button;
    public CameraButton generatorButton;
    public CameraButton sneakstersStartButton;
    public CameraButton mainHall1Button;
    public CameraButton mainHall2Button;
    public CameraButton outsideButton;
    public CameraButton sideHallButton;
    public CameraButton storageRoomButton;
    public CameraButton officeButton;
    public CameraButton theVoidButton;
    public CameraButton currentCameraButton;

    [Header("Rooms")]
    public RoomDetails mainStartArea;
    public RoomDetails generalArea1;
    public RoomDetails generator;
    public RoomDetails sneakstersStart;
    public RoomDetails mainHall1;
    public RoomDetails mainHall2;
    public RoomDetails outside;
    public RoomDetails sideHall;
    public RoomDetails storageRoom;
    public RoomDetails office;
    public RoomDetails theVoid;

    public string lookingAt;
    public void PlayerLookingAt(string _at)
    {
        lookingAt = _at;
    }
    public string getLookDirection()
    {
        return lookingAt;
    }
    public void moveEnemyTo(string _character, string _room, int _progression)
    {
        int _enem = returnCharacterNumber(_character);

        Debug.Log(_character + ". == " + _enem);

        mainStartArea.enemies[_enem] = 0;
        generalArea1.enemies[_enem] = 0;
        generator.enemies[_enem] = 0;
        sneakstersStart.enemies[_enem] = 0;
        mainHall1.enemies[_enem] = 0;
        outside.enemies[_enem] = 0;
        sideHall.enemies[_enem] = 0;
        storageRoom.enemies[_enem] = 0;
        office.enemies[_enem] = 0;

        RoomDetails _newRoom = returnRoom(_room);

        _newRoom.enemies[_enem] = _progression;

        audioSource.clip = soundEffects[0];
        audioSource.Play();
    }
    
    [System.Serializable]
    public struct RoomDetails {
        public int[] enemies;
        // adji
        // bemu
        // wich
        // skde
        // fog
        // bulb
    }
    int returnCharacterNumber(string _character)
    {
        switch (_character)
        {
            case "ADHI":
                return 0;
            case "BEMU":
                return 1;
            case "WICH":
                return 2;
            case "SKDE":
                return 3;
            case "FOG":
                return 4;
            case "BULB":
                return 5;
            default:
                return 6;
        }
    }
    RoomDetails returnRoom(string _room)
    {
        switch (_room)
        {
            case "mainStartArea":
                return mainStartArea;
            case "generalArea1":
                return generalArea1;
            case "generator":
                return generator;
            case "sneakstersStart":
                return sneakstersStart;
            case "mainHall1":
                return mainHall1;
            case "mainHall2":
                return mainHall2;
            case "outside":
                return outside;
            case "sideHall":
                return sideHall;
            case "storageRoom":
                return storageRoom;
            case "office":
                return office;
            default:
                return theVoid;
        }
    }
    public int returnCharacter(string _room, string _character)
    {
        RoomDetails _newRoom = returnRoom(_room);
        int _char = returnCharacterNumber(_character);

        return _newRoom.enemies[_char];
    }
    private void Awake()
    {
        currentCameraButton = mainHall2Button;
        currentCameraButton.BootUp();

        mainStartArea.enemies = new int[6];
        generalArea1.enemies = new int[6];
        generator.enemies = new int[6];
        sneakstersStart.enemies = new int[6];
        mainHall1.enemies = new int[6];
        outside.enemies = new int[6];
        sideHall.enemies = new int[6];
        storageRoom.enemies = new int[6];
        office.enemies = new int[6];
        theVoid.enemies = new int[6];
    }
    public void setCurrentRoom(CameraButton _button)
    {
        currentCameraButton.Restart();
        currentCameraButton = _button;
    }

}
