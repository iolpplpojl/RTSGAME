using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    Vector3 nowposition;
    public Item item;
    public int slotNum;
    Image img;

    void Start()
    {
        nowposition = transform.position;
        transform.SetSiblingIndex(1000);
        img = GetComponent<Image>();
        img.sprite = item.sprite;
    }
    // 클릭 이벤트 처리 (IPointerClickHandler)
    public void OnPointerClick(PointerEventData eventData)
    {
        // 클릭한 UI 요소에 대해 처리할 코드 작성
        Debug.Log("UI Element Clicked" + transform.name);
    }

    // 드래그 시작 이벤트 처리 (IBeginDragHandler)
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 시작 시 처리할 코드 작성
        Debug.Log("Drag Started");
        InventoryDragSlot.instance.gameObject.SetActive(true);
        InventoryDragSlot.instance.dragSlot = this;
        InventoryDragSlot.instance.DragSetImage(GetComponent<Image>());
        InventoryDragSlot.instance.transform.position = eventData.position;

    }

    // 드래그 중 이벤트 처리 (IDragHandler)
    public void OnDrag(PointerEventData eventData)
    {
        // 드래그 중 처리할 코드 작성
        // 드래그 중 요소의 위치 업데이트 예시
        InventoryDragSlot.instance.transform.position = eventData.position;
    }

    // 드래그 끝 이벤트 처리 (IEndDragHandler)
    public void OnEndDrag(PointerEventData eventData)
    {
        // 드래그가 끝날 때 처리할 코드 작성
        InventoryDragSlot.instance.SetColor(0);
        InventoryDragSlot.instance.dragSlot = null;
        InventoryDragSlot.instance.gameObject.SetActive(false);
        Debug.Log(eventData.position);
    }

    // 드롭 이벤트 처리 (IDropHandler)
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Element Dropped at: " + eventData.position + eventData.pointerDrag + " => " + eventData.pointerCurrentRaycast);
        ChangeItem(eventData.pointerDrag.gameObject.GetComponent<InventorySlot>());
    }

    void ChangeItem(InventorySlot From)
    {
        Item _item = item;
        item = From.item;
        img.sprite = item.sprite;
        From.item = _item;
        From.img.sprite = From.item.sprite;

    }
}
