using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class InventorySlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    Vector3 nowposition;
    public int slotNum;
    Image img;

    void Start()
    {
        nowposition = transform.position;
        transform.SetSiblingIndex(1000);
        img = GetComponent<Image>();
        if (GameManager.instance.storage[slotNum] != null)
        {
            img.sprite = GameManager.instance.storage[slotNum].sprite;
        }
        else
        {
            img.sprite = null;
        }
    }



   public void Update()
    {
        if (GameManager.instance.storage[slotNum] != null)
        {
            img.sprite = GameManager.instance.storage[slotNum].sprite;
        }
        else
        {
            img.sprite = null;
        }
    }
    // 클릭 이벤트 처리 (IPointerClickHandler)
    public void OnPointerClick(PointerEventData eventData)
    {
        // 클릭한 UI 요소에 대해 처리할 코드 작성
    }

    // 드래그 시작 이벤트 처리 (IBeginDragHandler)
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 시작 시 처리할 코드 작성
        if (GameManager.instance.storage[slotNum] != null)
        {
            InventoryDragSlot.instance.gameObject.SetActive(true);
            InventoryDragSlot.instance.dragSlot = this;
            InventoryDragSlot.instance.DragSetImage(GetComponent<Image>());
            Vector3 temp = Camera.main.ScreenToWorldPoint(eventData.position);
            temp.z = 0;
            InventoryDragSlot.instance.transform.position = temp;
        }

    }

    // 드래그 중 이벤트 처리 (IDragHandler)
    public void OnDrag(PointerEventData eventData)
    {
        if (GameManager.instance.storage[slotNum] != null)
        {
            // 드래그 중 처리할 코드 작성
            // 드래그 중 요소의 위치 업데이트 예시
            Vector3 temp = Camera.main.ScreenToWorldPoint(eventData.position);
            temp.z = 0;
            InventoryDragSlot.instance.transform.position = temp;
        }
    }   

    // 드래그 끝 이벤트 처리 (IEndDragHandler)
    public void OnEndDrag(PointerEventData eventData)
    {
        // 드래그가 끝날 때 처리할 코드 작성
        InventoryDragSlot.instance.SetColor(0);
        InventoryDragSlot.instance.dragSlot = null;
        InventoryDragSlot.instance.gameObject.SetActive(false);
    }

    // 드롭 이벤트 처리 (IDropHandler)
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Element Dropped at: " + eventData.position + eventData.pointerDrag + " => " + eventData.pointerCurrentRaycast);

        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject != null)
            {
                if (GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] != null)
                {
                    ChangeItem(eventData.pointerDrag.gameObject.GetComponent<InventorySlot>());
                }
            }
        }
    }

    void ChangeItem(InventorySlot From) 
    {
        Item _item = GameManager.instance.storage[From.slotNum];
        Item _item2 = GameManager.instance.storage[slotNum];

        GameManager.instance.storage[From.slotNum] = _item2;
        GameManager.instance.storage[slotNum] = _item;

    }
}
