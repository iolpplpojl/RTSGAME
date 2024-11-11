using UnityEngine;
using UnityEngine.EventSystems;

public class EquipSlot : MonoBehaviour, IPointerClickHandler, IDropHandler
{

    public Item item;

    public void OnDrop(PointerEventData eventData)
    {
        //¿Â¬¯;
        if (GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] != null)
        {
            Debug.Log("¿Â¬¯");
            if (InventoryUI.Instance.goons.EquipItem(GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum]))
            {
                GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] = null;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //«ÿ¡¶;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
