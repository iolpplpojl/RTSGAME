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
    public RNG SpawnRandom;
    public RNG SpawnerRandom;
    public RNG ChestRandom;
    public RNG DungeonRandom;
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
        
        DamageRandom = new RNG(0,seed);
        ShopRandom = new RNG(0,seed);
        ContractRandom =new RNG(0,seed);
        MapRandom = new RNG(0,seed);
        SpawnRandom = new RNG(0,seed); //�� ����� ����
        SpawnerRandom = new RNG(0, seed); // �� ���� Ȯ�� ����
        ChestRandom = new RNG(0, seed);
        DungeonRandom = new RNG(0, seed);
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

    public void toNextFloor()
    {
        floor++;
        DamageRandom.Reset();
        ShopRandom.Reset();
        ContractRandom.Reset();
        MapRandom.Reset();
        SpawnRandom.Reset();
        SpawnerRandom.Reset();
        ChestRandom.Reset();
        DungeonRandom.Reset(); 
        RoomManager.instance.Reset();
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
                AlertManager.instance.Append("���� �߿��� ������ �� �� �����ϴ�.");
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

    public void ExecuteDungeonEnter(GameObject Dungeon,List<GameObject> n)
    {
        if(nowDungeon != null)
        {
            Destroy(nowDungeon);
        }
        nowDungeon = Instantiate(Dungeon, INGAME.transform);
        nowDungeon.GetComponent<DungeonManager>().Goons = n;
        GameManager.instance.resetDungeon(nowDungeon.GetComponent<DungeonManager>());

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
        Debug.Log("Ŭ����");
        inFight = false;
    }

}



public class RNG
{
    System.Random rand;
    public int nexted;


    public int nextedtemp;
    public RNG(int count,int seed)
    {
        rand = new System.Random(seed);
        for(int i = 0; i < count; i++)
        {
            Range(0, 1);
        }

    }

    public void Reset()
    {
        nexted += nextedtemp;
        nextedtemp = 0;
    }
    
    public int Range(int min, int max)
    {
        nextedtemp++;

        return rand.Next(min, max);
    }
    public float Range(float min,float max)
    {
        float value = (float)rand.NextDouble() * (max - min) + min;
        nextedtemp++;
        Debug.Log(value + "RNG �����");
        return value;
    }
}
