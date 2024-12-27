using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager instance;

    public GameObject nowDungeon;

    public int floor;
    public int seed;
    public Sprite goldsprite;

    public int gold;
    public bool inFight = true;

    public int storageCount = 30;
    public List<Iitem> storage = new List<Iitem>();
    public GameObject Inventory;
    public GameObject Popup;


    public GameObject Next;
    public GameObject Dungeon;


    public GameObject INGAME;
    public GameObject OUTGAME;


    public RNG DamageRandom;
    public RNG ShopRandom;
    public RNG ContractRandom;
    public RNG MapRandom;

    public void SwitchScreen()
    {
        INGAME.SetActive(!INGAME.activeSelf);
        OUTGAME.SetActive(!OUTGAME.activeSelf);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        for(int i = 0; i < storageCount; i++)
        {
            storage.Add(null);
        }
        Random.InitState(seed);
        
        DamageRandom = new RNG(10,seed);
        ShopRandom = new RNG(10,seed);
        ContractRandom =new RNG(10,seed);
        MapRandom = new RNG(10,seed);

    }

    public int Dice(int times, int max)
    {
        int num = 0;
        for(int i = 0; i < times; i++)
        {
            num += Random.Range(1, max + 1);
        }
        return num;
    }
    public int Dice(int[] list)
    {
        int num = 0;
        for (int i = 0; i < list[0]; i++)
        {
            num += Random.Range(1, list[1] + 1);
        }
        return num;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(!Inventory.activeSelf);
            if (Inventory.activeSelf == false)
            {
                ItemDescriptor.instance.gameObject.SetActive(false);
            }

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (inFight)
            {
                AlertManager.instance.Append("전투 중에는 지도를 볼 수 없습니다.");
            }
            else
            {
                SwitchScreen();
            }
        }
        Next.SetActive( !inFight && !OUTGAME.activeSelf);
        
    }
    public void testDungeon()
    {
        Destroy(nowDungeon);
        nowDungeon = Instantiate(Dungeon,INGAME.transform);
    }

    public void ExecuteDungeonEnter(GameObject Dungeon)
    {
        if(nowDungeon != null)
        {
            Destroy(nowDungeon);
        }
        nowDungeon = Instantiate(Dungeon, INGAME.transform);
        SwitchScreen();
    }

    public void resetDungeon(DungeonManager dungeon)
    {
        StartCoroutine(resetDungeonCoroutine(dungeon));
    }
    IEnumerator resetDungeonCoroutine(DungeonManager dungeon)
    {
        yield return GoonsManager.instance.setPos(dungeon);
        yield return null;
        GoonsManager.instance.deBuff();
        nowDungeon = dungeon.gameObject;
        inFight = true;
        yield return null;
        dungeon.SpawnEnemy();
    }
    
    public void DungeonClear()
    {
        Debug.Log("클리어");
        inFight = false;
    }

}



public class RNG
{
    System.Random rand;
    int nexted;

    public RNG(int count,int seed)
    {
    
        rand = new System.Random(seed);
        for(int i = 0; i < count; i++)
        {
            Range(0, 1);
        }

        Debug.Log($"TestSeed : {rand.Next()}");
    }

    
    public int Range(int min, int max)
    {
        nexted++;
        Debug.Log(rand + " " + nexted);

        return rand.Next(min, max);
    }
    public float Range(float min,float max)
    {
        float value = (float)rand.NextDouble() * (max - min) + min;
        nexted++;
        Debug.Log(rand + " " + nexted);

        return value;
    }
}
