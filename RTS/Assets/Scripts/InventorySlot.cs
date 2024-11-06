using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    Vector3 nowposition;
    

    void Start()
    {
        nowposition = transform.position;
        transform.SetSiblingIndex(1000);
    }
    // Ŭ�� �̺�Ʈ ó�� (IPointerClickHandler)
    public void OnPointerClick(PointerEventData eventData)
    {
        // Ŭ���� UI ��ҿ� ���� ó���� �ڵ� �ۼ�
        Debug.Log("UI Element Clicked" + transform.name);
    }

    // �巡�� ���� �̺�Ʈ ó�� (IBeginDragHandler)
    public void OnBeginDrag(PointerEventData eventData)
    {
        // �巡�� ���� �� ó���� �ڵ� �ۼ�
        Debug.Log("Drag Started");
        InventoryDragSlot.instance.dragSlot = this;
        InventoryDragSlot.instance.DragSetImage(GetComponent<Image>());
        InventoryDragSlot.instance.transform.position = eventData.position;
    }

    // �巡�� �� �̺�Ʈ ó�� (IDragHandler)
    public void OnDrag(PointerEventData eventData)
    {
        // �巡�� �� ó���� �ڵ� �ۼ�
        Debug.Log("Dragging");
        // �巡�� �� ����� ��ġ ������Ʈ ����
        InventoryDragSlot.instance.transform.position = eventData.position;
    }

    // �巡�� �� �̺�Ʈ ó�� (IEndDragHandler)
    public void OnEndDrag(PointerEventData eventData)
    {
        // �巡�װ� ���� �� ó���� �ڵ� �ۼ�
        InventoryDragSlot.instance.SetColor(0);
        InventoryDragSlot.instance.dragSlot = null;
    }

    // ��� �̺�Ʈ ó�� (IDropHandler)
    public void OnDrop(PointerEventData eventData)
    {
        // �巡���� ��Ұ� ��ӵ� ��ġ�� ���� ó���� �ڵ� �ۼ�
        Debug.Log("Element Dropped");
    }
}
