using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    public List<itemdb> commonItem = new List<itemdb>();

    public List<GameObject> firstroom = new List<GameObject>();

    public List<goonsdb> commongoons = new List<goonsdb>();
    public List<goonsdb> enemygoons = new List<goonsdb>();

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
