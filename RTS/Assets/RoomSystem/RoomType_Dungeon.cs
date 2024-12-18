using UnityEngine;

public class RoomType_Dungeon : MonoBehaviour, IRoomType
{
    public GameObject Dungeon;
    public void Setup()
    {

    }
    public void Action()
    {
        GameManager.instance.ExecuteDungeonEnter(Dungeon);
    }
}
