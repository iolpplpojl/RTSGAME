using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager instance;

    public GameObject nowDungeon;


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

        Next.SetActive(!inFight);
    }
    public void testDungeon()
    {
        Destroy(nowDungeon);
        nowDungeon = Instantiate(Dungeon);
    }
    public void resetDungeon(DungeonManager dungeon)
    {
        GoonsManager.instance.setPos(dungeon);
        GoonsManager.instance.deBuff();
        nowDungeon = dungeon.gameObject;
        inFight = true;

    }
    public void DungeonClear()
    {
        Debug.Log("Å¬¸®¾î");
        inFight = false;
    }
}
