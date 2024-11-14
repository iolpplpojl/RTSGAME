using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int Gold;
    public List<Item> item = new List<Item>();


    public List<ChestData> slot = new List<ChestData>();


    void Start() {
        if (Gold > 0) {
            ChestData temp = new ChestData();
            temp.type = 0;
            temp.gold = Gold;
            slot.Add(temp);
        }

        foreach (var temp in item)
        {
            ChestData kek = new ChestData();
            kek.type = 1;
            kek.item = temp;
            slot.Add(kek);
        }
    }

    private void OnMouseUpAsButton()
    {
        
        ChestUI.instance.OpenChests(this);
        //«ÿ¡¶;
    }
}

public class ChestData
{
    public int type;
    public int gold;
    public Item item;
}
