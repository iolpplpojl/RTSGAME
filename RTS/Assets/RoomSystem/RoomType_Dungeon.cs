using UnityEngine;

[CreateAssetMenu(fileName = "Dungeon", menuName = "Room/Dungeon")]

public class RoomType_Dungeon : ScriptableObject, IRoomType
{
    public GameObject Dungeon;
    public bool visited;
    public void Setup()
    {

    }
    public void Action()
    {
        if (visited == false)
        {
            visited = true;
            GameManager.instance.ExecuteDungeonEnter(Dungeon);
        }
    }
}
