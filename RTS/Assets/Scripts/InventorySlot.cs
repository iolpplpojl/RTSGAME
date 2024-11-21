using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class InventorySlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, ISlot
{

    Vector3 nowposition;
    public int slotNum;
    Image img;
    public Iitem item { get; set; }  // Item�� �����ϴ� ����

    void Start()
    {
        nowposition = transform.position;
        transform.SetSiblingIndex(1000);
        img = GetComponent<Image>();
        if (GameManager.instance.storage[slotNum] != null)
        {
            item = GameManager.instance.storage[slotNum];
            img.sprite = item.sprite;
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
            item = GameManager.instance.storage[slotNum];
            img.sprite = item.sprite;
        }
        else
        {
            item = null;
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
            if (!(GameManager.instance.storage[slotNum] is Item) )
            {
                InventoryUI.Instance.usePanel.SetActive(true);
            }
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
        InventoryUI.Instance.usePanel.SetActive(false);

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
        Iitem _item = GameManager.instance.storage[From.slotNum];
        Iitem _item2 = GameManager.instance.storage[slotNum];

        GameManager.instance.storage[From.slotNum] = _item2;
        GameManager.instance.storage[slotNum] = _item;

    }
}
