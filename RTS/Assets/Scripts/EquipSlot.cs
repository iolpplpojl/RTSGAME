using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour, IPointerClickHandler, IDropHandler,ISlot
{


    public int slotNum;
    Image img;
    public Iitem item { get; set; }  // Item¿ª ¿˙¿Â«œ¥¬ ΩΩ∑‘



    void Start()
    {
        img = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //¿Â¬¯;
        if (GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] as Item != null)
        {
            Debug.Log("¿Â¬¯");
            if (InventoryUI.Instance.goons.EquipItem(GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] as Item))
            {
                GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] = null;
            }
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //«ÿ¡¶;
    }
    // Update is called once per frame
    void Update()
    {
        if (InventoryUI.Instance.goons != null)
        {
            if (InventoryUI.Instance.goons.items[slotNum] != null)
            {
                img.sprite = InventoryUI.Instance.goons.items[slotNum].sprite;
                item = InventoryUI.Instance.goons.items[slotNum];
            }
            else
            {
                img.sprite = null;
               // item = null;

            }
        }
    }

}
