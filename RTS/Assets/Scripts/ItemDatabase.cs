using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    public List<ScriptableObject> commonItem = new List<ScriptableObject>();
    public List<GameObject> firstroom = new List<GameObject>();


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public Iitem GetRandomItem()
    {
        var temp = Random.value;
        Iitem _item = null;
        if(temp <= 1f)
        {
            _item = commonItem[Random.Range(0, commonItem.Count)] as Iitem;
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
