using System.Collections.Generic;
    using UnityEngine;

public class RoomManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject room;

    public static RoomManager instance;

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
    public bool moving = false;
    Room nowRoom;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Clear()
    {
           moving = true;
    }
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

            // 방향을 배열에 저장
            Vector2Int[] directions = new Vector2Int[]
            {
               Vector2Int.left,
                  Vector2Int.right,
                Vector2Int.up,
              Vector2Int.down
            };

            // 배열을 무작위로 섞기
            ShuffleArray(directions);

            // 섞인 방향에 따라 방 생성
            foreach (var direction in directions)
            {
                RoomGeneration(room.Pos + direction, room);
            }
        }
        else if (!roomgencomplete)
        {
            Debug.Log("생성 완료됨.");
            roomgencomplete = true;
        }
        foreach (var temp in list_room)
        {

            temp.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (moving == true)
        {

            foreach (var temp in nowRoom.InRoom)
            { 
               temp.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            foreach (var temp in nowRoom.OutRoom)
            {
                temp.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        } 
        nowRoom.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    // 배열을 무작위로 섞는 메서드
    void ShuffleArray(Vector2Int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int randomIndex = Random.Range(i, array.Length);
            // 스왑
            Vector2Int temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    public void MoveRoom(Room room)
    {
        if (moving == true)
        {
            if (nowRoom.InRoom.Contains(room) || nowRoom.OutRoom.Contains(room))
            {
                Debug.Log("무브성공");
                nowRoom.GetComponent<SpriteRenderer>().color = Color.white;
                nowRoom = room;
                nowRoom.GetComponent<SpriteRenderer>().color = Color.red;
                moving = false;
            }
            else
            {
                Debug.Log("무브불가");
            }
        }
        else
        {
            Debug.Log("무브불가");
        }
    }

    void SetConnection(Room from, Room to)
    {
        var temp = from.Pos - to.Pos;
        if(temp == Vector2Int.left)
        {
            from.doors[1].SetActive(true);
        }
        if (temp == Vector2Int.right)
        {
            from.doors[0].SetActive(true);

        }
        if (temp == Vector2Int.up)
        {
            from.doors[3].SetActive(true);
        }
        if (temp == Vector2Int.down)
        {
            from.doors[2].SetActive(true);
        }
    }

    void RoomGeneration(Vector2Int index, Room room)
    {
        Debug.Log(index);
        if (roommax <= roomcount)
        {
            return;
        }
        if (room_grid[index.x, index.y] != 0)
            return;

        if (room.ConnectCount >= 1)
        {
            if(Random.value < 0.9f && index != Vector2Int.zero)
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
        SetConnection(room, init.GetComponent<Room>());
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
        nowRoom = init.GetComponent<Room>();
        nowRoom.GetComponent<SpriteRenderer>().color = Color.red;

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
