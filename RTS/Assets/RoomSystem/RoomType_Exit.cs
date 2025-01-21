using UnityEngine;

[CreateAssetMenu(fileName = "Exit", menuName = "Room/Exit")]

public class RoomType_Exit : ScriptableObject, IRoomType
{
    public Incounter Event;
    public Incounter _event;
    [field: SerializeField] public bool visited { get; set; }

    public void Setup()
    {
        _event = Instantiate(Event);
        _event.Setup();
    }
    public void Action()
    {
        _event.Open();
    }   
}
