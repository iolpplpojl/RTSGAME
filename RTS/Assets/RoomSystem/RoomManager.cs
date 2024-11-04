using UnityEngine;
using System.Collections.Generic;
public class RoomManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject room;

    List<GameObject> list_room = new List<GameObject>();
    Queue<Room> roomQueue = new Queue<Room>();
    int roomW = 20;
    int roomH = 12;
    int gridX = 20;
    int gridY = 20;
    int[,] room_grid; // X , Y
    int roomcount = 0;
    int roommax = 12;
    bool roomgencomplete = false;

    void Start()
    {
        room_grid = new int[gridX,gridY];
        StartRoomGeneration(new Vector2Int(gridX/2,gridY/2));
    }
    void Update()
    {
        if (roomQueue.Count > 0 && roommax > roomcount && !roomgencomplete)
        {
            Room room = roomQueue.Dequeue();
            RoomGeneration(room.Pos + Vector2Int.left,room);
            RoomGeneration(room.Pos + Vector2Int.right, room);
            RoomGeneration(room.Pos + Vector2Int.up, room);
            RoomGeneration(room.Pos + Vector2Int.down,room);

        }
        else if(!roomgencomplete)
        {
            Debug.Log("»ý¼º ¿Ï·áµÊ.");
            roomgencomplete = true;
        }
    }

    void RoomGeneration(Vector2Int index, Room room)
    {
        Debug.Log(index);
        if (room_grid[index.x, index.y] != 0)
            return;
        if (room.ConnectCount >= 1)
        {
            if(Random.value < (0.44f * room.ConnectCount) && index != Vector2Int.zero)
            {
                return;
            }
        }



        int x = index.x;
        int y = index.y;
        room_grid[x, y] = 1;
        var init = Instantiate(this.room, GetPositionFromGridIndex(index), Quaternion.identity);
        init.name = $"Room - {roomcount}";
        roomcount++;
        init.GetComponent<Room>().Pos = index;
        list_room.Add(init);
        room.ConnectCount++;
        room.OutRoom.Add(init.GetComponent<Room>());
        init.GetComponent<Room>().InRoom.Add(room);
        roomQueue.Enqueue(init.GetComponent<Room>());

    }

    public void Reset()
    {
        foreach (var temp in list_room)
        {
            Destroy(temp);
        }
        list_room = new List<GameObject>();
        roomQueue = new Queue<Room>();
        room_grid = new int[gridX, gridY];
        roomcount = 0;
        StartRoomGeneration(new Vector2Int(gridX / 2, gridY / 2));
        roomgencomplete = false;
    }
    Vector3 GetPositionFromGridIndex(Vector2Int gridIndex)
    {
        int X = gridIndex.x;
        int Y = gridIndex.y;
        return new Vector3(roomW * (X - gridX / 2), roomH * (Y - gridY / 2));
    }

    void StartRoomGeneration(Vector2Int index)
    {
        int x = index.x;
        int y = index.y;
        room_grid[x, y] = 1;
        var init = Instantiate(room, GetPositionFromGridIndex(index), Quaternion.identity);
        init.name = $"Room - {roomcount}";
        roomcount++;
        init.GetComponent<Room>().Pos = index;
        list_room.Add(init);
        roomQueue.Enqueue(init.GetComponent<Room>());

    }

    void OnDrawGizmos()
    {
        Color col = new Color(0, 1, 1, 0.05f);
        Gizmos.color = col;
        for(int i = 0; i < gridX; i++)
        {
            for(int k = 0; k< gridY; k++)
            {
                Vector3 pos = GetPositionFromGridIndex(new Vector2Int(i, k));
                Gizmos.DrawWireCube(new Vector3(pos.x, pos.y), new Vector3(roomW, roomH, 1));
            }
        }
    }
}
