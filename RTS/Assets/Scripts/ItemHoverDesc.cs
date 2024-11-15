using UnityEngine;
using UnityEngine.EventSystems;  // IPointerEnterHandler, IPointerExitHandler를 사용하기 위해 필요

public class ItemHoverDesc : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Item item;


    void Update()
    {
        item = GetComponent<ISlot>().item;
    }

    // 마우스가 UI 요소 위에 올라갔을 때 호출됩니다.
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(item + " 호버링 " + eventData.pointerEnter);
    }

    // 마우스가 UI 요소를 벗어났을 때 호출됩니다.
    public void OnPointerExit(PointerEventData eventData)
    {

    }
}