using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector2Int Pos;
    public int ConnectCount = 0;
    public List<Room> OutRoom = new List<Room>();
    public List<Room> InRoom = new List<Room>();
    public List<GameObject> doors = new List<GameObject>();
    public IRoomType roomType;




    public void Setup()
    {
        roomType.Setup();
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


