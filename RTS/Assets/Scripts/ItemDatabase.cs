using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    public List<itemdb> commonItem = new List<itemdb>();
    public List<GameObject> firstroom = new List<GameObject>();
    public List<goonsdb> commongoons = new List<goonsdb>();
    public List<goonsdb> enemygoons = new List<goonsdb>();
    public GameObject Chest;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


    }
    public Iitem GetRandomItem(RNG randomizer)
    {
        var temp = randomizer.Range(0f, 1f);
        Iitem _item = null;
        int idx = 0;
        if(temp <= 1f)
        {
            idx = 0;
        }
        _item = commonItem[idx].items[randomizer.Range(0, commonItem[idx].items.Count)] as Iitem;

        Debug.Log(_item);
        return _item;
    }

    public List<ChestData> GetRandomChestData(int rank)
    {
        //...골드;;;
        List<ChestData> lst = new List<ChestData>();
        for(int i = 0; i < 4; i++)
        {
            var temp = GameManager.instance.ChestRandom.Range(0f, 1f);
            if (temp > 0.5f + (0.1f*rank))
            {
                ChestData data = new ChestData();
                data.type = 1;
                data.item = GetRandomItem(GameManager.instance.ChestRandom);
                lst.Add(data);
            }
        }
        var z = GameManager.instance.ChestRandom.Range(0f, 1f);
        if (z > 0.5f + (0.1f * rank)) {
            ChestData gold = new ChestData();
            gold.type = 0;
            gold.gold = GameManager.instance.ChestRandom.Range(10, 30 * (rank+30));
            lst.Add(gold);
        }
        Debug.Log(lst.Count + " 로 상자 셋팅 완료.");

        if(lst.Count == 0)
        {
            return null;
        }
        return lst;
    }
    public GameObject GetRandomRoom()
    {
        GameObject temp = null;
        switch (GameManager.instance.floor)
        {
            case 0:
                temp = firstroom[GameManager.instance.DungeonRandom.Range(0, firstroom.Count)];
                break;
            case 1:
                temp = firstroom[GameManager.instance.DungeonRandom.Range(0, firstroom.Count)];

                break;
        }
        return temp;
    }

    public GameObject GetEnemyGoons()
    {
        var temp = GameManager.instance.SpawnRandom.Range(0f, 1f);
        int idx = 0;
        GameObject Goons = null;
        if (temp <= 1f)
        {
            idx = 0;
        }
        Goons = enemygoons[idx].goons[Random.Range(0, enemygoons[idx].goons.Count)];
        return Goons;
    }

    public GameObject GetEnemyGoons(int rank)
    {
        var temp = GameManager.instance.SpawnRandom.Range(0f, 1f);
        int idx = 0;
        GameObject Goons = null;
        if (temp <= 1f)
        {
            idx = 0;
        }
        Goons = enemygoons[idx].goons[Random.Range(0, enemygoons[idx].goons.Count)];
        return Goons;

    }
    public GameObject GetRandomGoons(int rank)
    {
        //var temp = GameManager.instance.SpawnRandom.Range(0f, 1f);
        int idx = 0;
        GameObject Goons = null;
        if(1f <= 1f)
        {
            idx = 0;
        }
        Goons = commongoons[idx].goons[GameManager.instance.ContractRandom.Range(0, commongoons[idx].goons.Count)];
        return Goons;

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
