using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class ShopSlot : MonoBehaviour, IPointerClickHandler, ISlot
{
    public product data;
    public Image img;
    public TMP_Text txt;
    public Item item { get; set; }  // Item을 저장하는 슬롯


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            img.sprite = data.item.sprite;
            txt.text = data.item.itemname + string.Format("   {0} 골드", data.price);
        item = data.item;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //구매;
        ShopUI.instance.Buy(this);
    }

}
