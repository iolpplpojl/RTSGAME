using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;
using TMPro;
public class ChestSlot : MonoBehaviour, IPointerClickHandler
{

    public ChestData data;
    public Image img;
    public TMP_Text txt;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if(data.type == 0)
        {
            img.sprite = GameManager.instance.goldsprite;
            txt.text = string.Format("{0} °ñµå", data.gold);
        }
        else
        {
            img.sprite = data.item.sprite;
            txt.text = data.item.itemname;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        ChestUI.instance.GetItem(this);

    }
}
