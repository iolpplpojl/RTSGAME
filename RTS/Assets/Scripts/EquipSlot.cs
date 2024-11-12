using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour, IPointerClickHandler, IDropHandler
{


    public int slotNum;
    Image img;



    void Start()
    {
        img = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //¿Â¬¯;
        if (GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] != null)
        {
            Debug.Log("¿Â¬¯");
            if (InventoryUI.Instance.goons.EquipItem(GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum],slotNum))
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
            }
            else
            {
                img.sprite = null;
            }
        }
    }

}
