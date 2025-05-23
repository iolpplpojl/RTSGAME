using System.Collections;
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
    public Room nowRoom;

    public List<ScriptableObject> roomtype = new List<ScriptableObject>();
    bool endroomGen = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    
    public void SetVisitedList(List<bool> visited)
    {
        int k = 0;
        foreach(bool i in visited)
        {
            Debug.Log(i);                                                                       
            list_room[k].GetComponent<Room>().roomType.visited = i;
            k++;
        }
    }

    public void SetNowPos(int i)
    {
        nowRoom = list_room[i].GetComponent<Room>();
    }

    public List<bool> GetVisitedList()
    {
        List<bool> lst = new List<bool>();

        foreach(var r in list_room)
        {
            Room rm = r.GetComponent<Room>();
            lst.Add(rm.roomType.visited);
        }


        return lst;

    }

    public int GetNowRoomCount()
    {
        int i = 0;
        foreach (GameObject room in list_room)
        {
            
            if(room.GetComponent<Room>() == nowRoom)
            {
                Debug.Log(i);
                return i;
            }
            i++;
        }
        return -1;
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
        moving = !GameManager.instance.inFight;

    }

    // 배열을 무작위로 섞는 메서드
    void ShuffleArray(Vector2Int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int randomIndex = GameManager.instance.MapRandom.Range(i, array.Length);
            // 스왑
            Vector2Int temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    public bool MoveRoom(Room room)
    {
        if (moving == true)
        {
            if (nowRoom.InRoom.Contains(room) || nowRoom.OutRoom.Contains(room) || nowRoom == room)
            {
                Debug.Log("무브성공");
                nowRoom.GetComponent<SpriteRenderer>().color = Color.white;
                nowRoom = room;
                nowRoom.GetComponent<SpriteRenderer>().color = Color.red;
                moving = false;
                return true;
            }
            else
            {
                Debug.Log("무브불가");
                return false;
            }
        }
        else
        {
            Debug.Log("무브불가");
            return false;

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

    public void RoomGen()
    {
        while (roomQueue.Count > 0 && roommax > roomcount)
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
            if(GameManager.instance.MapRandom.Range(0f,1f) < 0.9f && index != Vector2Int.zero)
            {
                return;
            }
        }

        int x = index.x;
        int y = index.y;
        room_grid[x, y] = 1;
        var init = Instantiate(this.room, transform.position + GetPositionFromGridIndex(index), Quaternion.identity,transform);
        init.name = $"Room - {roomcount}";
        roomcount++;
        init.GetComponent<Room>().Pos = index;
        list_room.Add(init);
        room.ConnectCount++;
        room.OutRoom.Add(init.GetComponent<Room>());
        SetConnection(room, init.GetComponent<Room>());
        init.GetComponent<Room>().InRoom.Add(room);



        if (roomcount == 0)
        {
        }
        else
        {
            int type;
            do
            {
              type = GameManager.instance.MapRandom.Range(0, 3);
            } while (endroomGen == true && type == 0 || (endroomGen == false && roomcount < (roommax * 10) / 17&& type == 0));

            init.GetComponent<Room>().roomType = Instantiate(roomtype[type]) as IRoomType;
            if (type == 0)
            {
                endroomGen = true;
            }
        }
        roomQueue.Enqueue(init.GetComponent<Room>());
        init.GetComponent<Room>().Setup();


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
    
    public void DoLoad(int pos, List<bool> vi)
    {
        StartCoroutine(Load(pos,vi));
    }
    IEnumerator Load(int pos, List<bool> vi)
    {
        Reset();
        SetVisitedList(vi);
        SetNowPos(pos);
        yield return null;
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
        var init = Instantiate(room, transform.position+GetPositionFromGridIndex(index), Quaternion.identity, transform);
        init.name = $"Room - {roomcount}";
        roomcount++;
        init.GetComponent<Room>().Pos = index;
        list_room.Add(init);
        roomQueue.Enqueue(init.GetComponent<Room>());
        nowRoom = init.GetComponent<Room>();
        nowRoom.GetComponent<SpriteRenderer>().color = Color.red;
        endroomGen = false;
        init.GetComponent<Room>().roomType = Instantiate(roomtype[roomtype.Count-1]) as IRoomType;
        init.GetComponent<Room>().Setup();
        RoomGen();
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
