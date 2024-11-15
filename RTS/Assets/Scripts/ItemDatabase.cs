using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    public List<Item> commonItem = new List<Item>();

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

        if(temp > 1f)
        {
            _item = commonItem[Random.Range(0, commonItem.Count)];
        }
        return _item;
    }
}
