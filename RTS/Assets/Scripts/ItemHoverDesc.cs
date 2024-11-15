using UnityEngine;
using UnityEngine.EventSystems;  // IPointerEnterHandler, IPointerExitHandler�� ����ϱ� ���� �ʿ�

public class ItemHoverDesc : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Item item;


    void Update()
    {
        item = GetComponent<ISlot>().item;
    }

    // ���콺�� UI ��� ���� �ö��� �� ȣ��˴ϴ�.
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(item + " ȣ���� " + eventData.pointerEnter);
    }

    // ���콺�� UI ��Ҹ� ����� �� ȣ��˴ϴ�.
    public void OnPointerExit(PointerEventData eventData)
    {

    }
}