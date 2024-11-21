using UnityEngine;

public class ChestUI : MonoBehaviour
{

    public static ChestUI instance;

    public Chest chest;

    public GameObject parent;
    public GameObject slot;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        gameObject.SetActive(false);
    }

    public void OpenChests(Chest chest)
    {
        this.chest = chest;
        foreach (Transform temp in parent.transform)
        {
            Destroy(temp.gameObject);
        }
        int i = 0;

        foreach (var temp in chest.slot)
        {
            var kek = Instantiate(slot, parent.transform);
            var pepe = kek.GetComponent<ChestSlot>();
            pepe.data = temp;
        }
        gameObject.SetActive(true);
    }
    
    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void GetItem(ChestSlot slot)
    {
        if (slot.data.type == 0)
        {
            GameManager.instance.gold += slot.data.gold;
            chest.slot.Remove(slot.data);
            if (chest.slot.Count == 0)
            {
                Close();
                Destroy(chest.gameObject);
            }
            else
            {
                OpenChests(chest);
            }
            return;
        }
        else
        {
            for (int i = 0; i < GameManager.instance.storageCount; i++)
            {
                if (GameManager.instance.storage[i] == null)
                {
                    GameManager.instance.storage[i] = slot.data.item;
                    chest.slot.Remove(slot.data);
                    if (chest.slot.Count == 0)
                    {
                        Close();
                        Destroy(chest.gameObject);
                        ItemDescriptor.instance.gameObject.SetActive(false);
                    }
                    else
                    {
                        OpenChests(chest);
                    }

                    return;
                }
            }
            Debug.Log("인벤 모자람!!");
        }
    }


}
