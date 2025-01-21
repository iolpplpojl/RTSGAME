using UnityEngine;

[CreateAssetMenu(fileName = "First", menuName = "Room/First")]

public class RoomType_First : ScriptableObject, IRoomType
{
    [field: SerializeField] public bool visited { get; set; }

    public void Setup()
    {

    }
    public void Action()
    {
    }
}

