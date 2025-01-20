using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{

    public static SaveSystem instance;
    private void Awake()
    {
       if(instance == null)
       {
            instance = this;
       }
    }

    [ContextMenu("DOSAVE")]
    public void Save()
    {
        GoonsManager goonsManager = GoonsManager.instance;
        GameManager gameManager = GameManager.instance;
        RoomManager roomManager = RoomManager.instance;

        SaveData sav = new SaveData();
        sav.nowpos = roomManager.GetNowRoomCount();
        
        sav.gold = gameManager.gold;
        sav.floor = gameManager.floor;
        sav.seed = gameManager.seed;
        sav.DamageRandom = gameManager.DamageRandom.nexted;
        sav.ShopRandom = gameManager.ShopRandom.nexted;
        sav.ContractRandom = gameManager.ContractRandom.nexted;
        sav.MapRandom = gameManager.MapRandom.nexted;
        sav.SpawnRandom = gameManager.SpawnRandom.nexted;
        sav.SpawnerRandom = gameManager.SpawnerRandom.nexted;
        sav.ChestRandom = gameManager.ChestRandom.nexted;
        sav.DungeonRandom = gameManager.DungeonRandom.nexted;

        sav.item = ItemDatabase.instance.GetInvenIndex();
        List<SaveGoonsData> Goon = new List<SaveGoonsData>();
        foreach(Goons goons in goonsManager.Goons)
        {
            SaveGoonsData g = new SaveGoonsData();
            g.goons = ItemDatabase.instance.GetGoonsIndex(goons);
            g.equip = ItemDatabase.instance.GetItemIndex(goons);
            Debug.Log(ItemDatabase.instance.GetItemIndex(goons));
            foreach(GameObject p in goons.members)
            {
                Player unit = p.GetComponent<Player>();
                
            }
            Goon.Add(g);
        }
        sav.goonsData = Goon;

        Debug.Log(JsonUtility.ToJson(sav));
    }

}

[System.Serializable]

public class SaveData
{
    public int nowpos;
    public int[] visited;

    public List<SaveInvenData> item;
    public int gold;
    
    public int seed;
    public int floor;
    //½ÃÇàÈ½¼ö
    public int DamageRandom;
    public int ShopRandom;
    public int ContractRandom;
    public int MapRandom;
    public int SpawnRandom;
    public int SpawnerRandom;
    public int ChestRandom;
    public int DungeonRandom;


    public List<SaveGoonsData> goonsData;

}


[System.Serializable]
public class SaveInvenData
{
    public int[] item;
    public SaveInvenData(int x, int y)
    {
        item = new int[] { x, y };
    }

}
[System.Serializable]
public class SaveGoonsData
{
    public List<SaveBuffData> buff;
    public List<SaveUnitData> unit;
    public List<SaveEquipMent> equip;
    public int[] goons;
}
[System.Serializable]
public class SaveBuffData
{
    public int buffCode;
    public int duration;
}
[System.Serializable]
public class SaveEquipMent
{
    public SaveEquipMent(int x, int y)
    {
        item = new int[] { x, y };
    }
    public int[] item;
}

[System.Serializable]
public class SaveUnitData
{
    public float addHealth;
    public float addDamage;
    public float addAttackTime;
    public int addDefence;
    public int addPower;
    public float Health;
}

