using UnityEngine;
using UnityEngine.EventSystems;  // IPointerEnterHandler, IPointerExitHandler를 사용하기 위해 필요

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

    // 마우스가 UI 요소 위에 올라갔을 때 호출됩니다.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            Debug.Log(item + " 호버링 " + eventData.pointerEnter);
            ItemDescriptor.instance.gameObject.SetActive(true);
            hover = true;
            ItemDescriptor.instance.SetUP(item);
        }

    }

    // 마우스가 UI 요소를 벗어났을 때 호출됩니다.
    public void OnPointerExit(PointerEventData eventData)
    {
        ItemDescriptor.instance.gameObject.SetActive(false);
        hover = false;
    }
}