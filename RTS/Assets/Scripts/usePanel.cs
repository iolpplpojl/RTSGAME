using UnityEngine;
using UnityEngine.EventSystems;
public class usePanel : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("���");
        if (GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] as Potion != null)
        {
            Debug.Log("����");
            if (InventoryUI.Instance.goons != null)
            {
                InventoryUI.Instance.goons.usePotion(GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] as Potion);
                GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] = null;
            }
            else
            {
                AlertManager.instance.Append("����� ����� �����ϴ�.");
            }
        }
    }
}
