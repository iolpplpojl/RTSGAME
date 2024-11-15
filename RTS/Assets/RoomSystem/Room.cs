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
    public Roomtype roomtype;



    public void RoomEvent()
    {
        RoomManager.instance.MoveRoom(this);
    }
    public void RoomSetUp()
    {
        Debug.Log(roomtype + " �¾��� ");
        switch (roomtype) {
            case Roomtype.Combat:
                Setup_room();
                break;
            case Roomtype.Shop:
                Setup_shop;
                break;
            case Roomtype.Event:
                Setup_event();
                break;
            case Roomtype.First:
                break;

               
        }

    }
    public void Setup_shop()
    {
        //���� ���� �� ���ο��� �¾� ����
    }
    public void Setup_room()
    {
        //���ӵ����ͺ��̽����� ������ ������ �ƹ��ų� �����ͼ� ����
    }
    public void Setup_event()
    {
        //�̺�Ʈ �Ŵ��� �����ؼ� �̺�Ʈ ����
    }

}


public enum Roomtype
{
    Combat,
    Shop,
    Event,
    First,
}