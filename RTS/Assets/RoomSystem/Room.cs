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
        Debug.Log(roomtype + " 셋업됨 ");
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
        //상인 생성 후 상인에서 셋업 실행
    }
    public void Setup_room()
    {
        //게임데이터베이스에서 프리팹 층별로 아무거나 꺼내와서 적용
    }
    public void Setup_event()
    {
        //이벤트 매니져 생성해서 이벤트 실행
    }

}


public enum Roomtype
{
    Combat,
    Shop,
    Event,
    First,
}