using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static InventoryUI Instance;

    public Goons goons;
    public GameObject img;
    public GameObject list;
    public GameObject itemInven;
    public GameObject invenSlot;
    public GameObject ItemList;
    public GameObject ItemSlot;
    public GameObject usePanel;
    public GameObject battlePanel;
    

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        gameObject.SetActive(false);
    }

    public void Start()
    {
        ItemListSetup();
    }
   

    public void Update()
    {
        battlePanel.SetActive(GameManager.instance.inFight);
        if (battlePanel.activeSelf)
        {
            usePanel.SetActive(false);
        }
    }


    public void ItemListSetup()
    {
        foreach (Transform temp in ItemList.transform)
        {
            Destroy(temp.gameObject);
        }
        int i = 0;

        foreach (var temp in GameManager.instance.storage)
        {
            var kek = Instantiate(ItemSlot, ItemList.transform);
            kek.GetComponentInChildren<InventorySlot>().slotNum = i;
            i++;
        }
    }

    public void ItemListReset()
    {
        foreach (Transform temp in ItemList.transform)
        {
            Destroy(temp.gameObject);
        }
        int i = 0;

        foreach(var temp in GameManager.instance.storage)
        {
            var kek = Instantiate(ItemSlot, ItemList.transform);
            kek.GetComponentInChildren<InventorySlot>().slotNum = i;
            i++;

        }
    }




    public void GoonsSelected(Goons goons)
    {
        foreach (Transform temp in list.transform)
        {
            Destroy(temp.gameObject);
        }
        foreach (Transform temp in itemInven.transform)
        {
            Destroy(temp.gameObject);
        }
        if (goons == null)
        {
            this.goons = null;
            foreach (Transform temp in img.transform)
            {
                Destroy(temp.gameObject);
            }
        }
        else
        {
            this.goons = goons;
            foreach (Transform temp in img.transform)
            {
                Destroy(temp.gameObject);
            }
            Instantiate(goons.face,img.transform);
            for(int i = 0; i < goons.ItemCount; i++)
            {
                var temp = Instantiate(invenSlot, itemInven.transform);
                temp.GetComponent<EquipSlot>().slotNum = i;

            }
        }
    }
}
