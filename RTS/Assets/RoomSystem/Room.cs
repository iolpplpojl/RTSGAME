using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Room : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector2Int Pos;
    public int ConnectCount = 0;
    public List<Room> OutRoom = new List<Room>();
    public List<Room> InRoom = new List<Room>();
    public List<GameObject> doors = new List<GameObject>();
    public IRoomType roomType;
    public TMP_Text text;



    public void Setup()
    {
        roomType.Setup();
        if (roomType as RoomType_Dungeon)
            text.text = "D";

        if (roomType as RoomType_Event)
            text.text = "Ev";

        if (roomType as RoomType_Exit)
            text.text = "Ex";

        if (roomType as RoomType_First)
            text.text = "F";
    }
    public void RoomEvent()
    {
        if (RoomManager.instance.MoveRoom(this))
        {
            Debug.Log(roomType);
            roomType.Action();
        }
    }
}


