using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

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


    [ContextMenu("DOLOAD")]
    public void Load()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "data.json");
        string json = File.ReadAllText(filePath);
        SaveData dat = JsonUtility.FromJson<SaveData>(json);
        Debug.Log(dat.gold);
        GameManager gm = GameManager.instance;

        gm.floor = dat.floor;
        gm.gold = dat.gold;
        gm.seed = dat.seed;
        gm.DamageRandom = new RNG(dat.DamageRandom, dat.seed);
        gm.ShopRandom = new RNG(dat.ShopRandom, dat.seed);
        gm.ContractRandom = new RNG(dat.ContractRandom, dat.seed);
        gm.MapRandom = new RNG(dat.MapRandom, dat.seed);
        gm.SpawnRandom = new RNG(dat.SpawnRandom, dat.seed);  
        gm.SpawnerRandom = new RNG(dat.SpawnerRandom, dat.seed);  
        gm.ChestRandom = new RNG(dat.ChestRandom, dat.seed);  
        gm.DungeonRandom = new RNG(dat.DungeonRandom, dat.seed);

        RoomManager rm = RoomManager.instance;
        rm.DoLoad(dat.nowpos,dat.visited);

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

        sav.visited = RoomManager.instance.GetVisitedList();

        sav.item = ItemDatabase.instance.GetInvenIndex();
        List<SaveGoonsData> Goon = new List<SaveGoonsData>();
        foreach(Goons goons in goonsManager.Goons)
        {
            SaveGoonsData g = new SaveGoonsData();
            g.goons = ItemDatabase.instance.GetGoonsIndex(goons);
            g.equip = ItemDatabase.instance.GetItemIndex(goons);
            g.buff = ItemDatabase.instance.GetBuffIndex(goons);
            List<SaveUnitData> Unit = new List<SaveUnitData>();
            foreach(GameObject p in goons.members)
            {
                SaveUnitData u = new SaveUnitData();
                
                Player unit = p.GetComponentInChildren<Player>();
                u.addAttackTime = unit.addAttackTime;
                u.addDamage = unit.addDamage; 
                u.addDefence = unit.addDefence;
                u.addHealth = unit.addHealth;
                u.Health = unit.Health; 
                u.addPower = unit.addPower;
               
                Unit.Add(u);
            }
            g.unit = Unit;
            Goon.Add(g);
        }
        sav.goonsData = Goon;
        string filePath = Path.Combine(Application.persistentDataPath, "data.json");
        File.WriteAllText(filePath, JsonUtility.ToJson(sav));
        Debug.Log(filePath);
        Debug.Log(JsonUtility.ToJson(sav));
    }

}

[System.Serializable]

public class SaveData
{
    public int nowpos;
    public List<bool> visited;

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

