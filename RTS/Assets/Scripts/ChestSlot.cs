using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;
using TMPro;
public class ChestSlot : MonoBehaviour, IPointerClickHandler,ISlot
{

    public ChestData data;
    public Image img;
    public TMP_Text txt;
    public Iitem item { get; set; }  // Item¿ª ¿˙¿Â«œ¥¬ ΩΩ∑‘


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if(data.type == 0)
        {
            img.sprite = GameManager.instance.goldsprite;
            txt.text = string.Format("{0} ∞ÒµÂ", data.gold);
            item = null;
        }
        else
        {
            item = data.item;
            img.sprite = data.item.sprite;
            txt.text = data.item.itemname;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        ChestUI.instance.GetItem(this);

    }
}
