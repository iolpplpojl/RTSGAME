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
    }
}
