using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int Gold;
    public List<Item> equipitem = new List<Item>();
    public List<Potion> potion = new List<Potion>();
    public List<Scroll> scroll = new List<Scroll>();
    public List<ChestData> slot = new List<ChestData>();


    void Start() {
        if (Gold > 0) {
            ChestData temp = new ChestData();
            temp.type = 0;
            temp.gold = Gold;
            slot.Add(temp);
        }

        foreach (var temp in equipitem)
        {
            ChestData kek = new ChestData();
            kek.type = 1;
            kek.item = temp;
            slot.Add(kek);
        }
        foreach(var temp in potion)
        {
            ChestData kek = new ChestData();
            kek.type = 1;
            kek.item = temp;
            slot.Add(kek);
        }
        foreach (var temp in scroll)
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
    public Iitem item;
}
