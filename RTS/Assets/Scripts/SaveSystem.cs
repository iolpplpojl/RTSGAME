using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

[System.Serializable]

public class SaveData
{
    int nowpos;
    int[] visited;

    List<int[,]> item;
    int gold;
    
    int seed;
    //½ÃÇàÈ½¼ö
    int DamageRandom;
    int ShopRandom;
    int ContractRandom;
    int MapRandom;
    int SpawnRandom;
    int SpawnerRandom;
    int ChestRandom;
    int DungeonRandom;


    SaveGoonsData goonsData;
}

[System.Serializable]
public class SaveGoonsData
{
    List<SaveBuffData> buff;
    List<SaveUnitData> unit;
    List<int[,]> equip;
    int[,] goons;
}
[System.Serializable]
public class SaveBuffData
{

}
[System.Serializable]
public class SaveUnitData
{

}

