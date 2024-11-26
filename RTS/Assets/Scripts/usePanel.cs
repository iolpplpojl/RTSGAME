using UnityEngine;
using UnityEngine.EventSystems;
public class usePanel : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("사용");
        if (GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] as Potion != null)
        {
            Debug.Log("포션");
            if (InventoryUI.Instance.goons != null)
            {
                InventoryUI.Instance.goons.usePotion(GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] as Potion);
                GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] = null;
            }
            else
            {
                AlertManager.instance.Append("사용할 대상이 없습니다.");
            }
        }
    }
}
