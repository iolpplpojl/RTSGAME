using UnityEngine;

[CreateAssetMenu(fileName = "Dungeon", menuName = "Room/Dungeon")]

public class RoomType_Dungeon : ScriptableObject, IRoomType
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
