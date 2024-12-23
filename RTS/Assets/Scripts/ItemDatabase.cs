using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    public List<itemdb> commonItem = new List<itemdb>();

    public List<GameObject> firstroom = new List<GameObject>();

    public List<goonsdb> commongoons = new List<goonsdb>();

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
        int idx = 0;
        if(temp <= 1f)
        {
            idx = 0;
        }
        _item = commonItem[idx].items[Random.Range(0, commonItem[idx].items.Count)] as Iitem;

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
[System.Serializable]
public class goonsdb
{
    public List<GameObject> goons = new List<GameObject>();
}
[System.Serializable]
public class itemdb
{
    public List<ScriptableObject> items = new List<ScriptableObject>();
}
