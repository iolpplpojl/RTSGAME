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
    // Ŭ�� �̺�Ʈ ó�� (IPointerClickHandler)
    public void OnPointerClick(PointerEventData eventData)
    {
        // Ŭ���� UI ��ҿ� ���� ó���� �ڵ� �ۼ�
    }

    // �巡�� ���� �̺�Ʈ ó�� (IBeginDragHandler)
    public void OnBeginDrag(PointerEventData eventData)
    {
        // �巡�� ���� �� ó���� �ڵ� �ۼ�
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

    // �巡�� �� �̺�Ʈ ó�� (IDragHandler)
    public void OnDrag(PointerEventData eventData)
    {
        if (GameManager.instance.storage[slotNum] != null)
        {
            // �巡�� �� ó���� �ڵ� �ۼ�
            // �巡�� �� ����� ��ġ ������Ʈ ����
            Vector3 temp = Camera.main.ScreenToWorldPoint(eventData.position);
            temp.z = 0;
            InventoryDragSlot.instance.transform.position = temp;
        }
    }   

    // �巡�� �� �̺�Ʈ ó�� (IEndDragHandler)
    public void OnEndDrag(PointerEventData eventData)
    {
        // �巡�װ� ���� �� ó���� �ڵ� �ۼ�
        InventoryDragSlot.instance.SetColor(0);
        InventoryDragSlot.instance.dragSlot = null;
        InventoryDragSlot.instance.gameObject.SetActive(false);
    }

    // ��� �̺�Ʈ ó�� (IDropHandler)
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
