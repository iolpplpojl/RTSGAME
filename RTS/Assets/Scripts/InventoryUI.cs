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


    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        gameObject.SetActive(false);
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
                Instantiate(invenSlot, itemInven.transform);
            }
        }
    }
}
