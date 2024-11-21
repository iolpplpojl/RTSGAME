using UnityEngine;
using UnityEngine.EventSystems;  // IPointerEnterHandler, IPointerExitHandler�� ����ϱ� ���� �ʿ�

public class ItemHoverDesc : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Iitem item;
    bool hover = false;

    void Update()
    {
        item = GetComponent<ISlot>().item;
        if (hover)
        {
            Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition - ItemDescriptor.instance.size);
            temp.z = 0;
            ItemDescriptor.instance.transform.position = temp;
        }
    }

    // ���콺�� UI ��� ���� �ö��� �� ȣ��˴ϴ�.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            Debug.Log(item + " ȣ���� " + eventData.pointerEnter);
            ItemDescriptor.instance.gameObject.SetActive(true);
            hover = true;
            ItemDescriptor.instance.SetUP(item);
        }

    }

    // ���콺�� UI ��Ҹ� ����� �� ȣ��˴ϴ�.
    public void OnPointerExit(PointerEventData eventData)
    {
        ItemDescriptor.instance.gameObject.SetActive(false);
        hover = false;
    }
}