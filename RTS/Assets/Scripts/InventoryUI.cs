using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static InventoryUI Instance;

    public Goons goons;
    public Image img;
    public GameObject list;
    public GameObject itemInven;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
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
            img.sprite = null;
        }
        else
        {
            this.goons = goons;
            img.sprite = this.goons.face;
        }
    }
}
