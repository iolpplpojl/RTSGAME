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
        }
    }
}
