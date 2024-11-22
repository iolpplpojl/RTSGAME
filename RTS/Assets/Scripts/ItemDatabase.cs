using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    public List<Item> commonItem = new List<Item>();
    public List<GameObject> firstroom = new List<GameObject>();


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public Item GetRandomItem()
    {
        var temp = Random.value;
        Item _item = null;
        if(temp <= 1f)
        {
            _item = commonItem[Random.Range(0, commonItem.Count)];
        }
        Debug.Log(_item);
        return _item;
    }
    public GameObject GetRandomRoom()
    {
        GameObject temp = null;
        switch (GameManager.instance.floor)
        {
            case 1:
                temp = firstroom[Random.Range(0, firstroom.Count)];
                break;
        }
        return temp;
    }   
}
