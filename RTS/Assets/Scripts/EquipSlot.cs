using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour, IPointerClickHandler, IDropHandler,ISlot
{


    public int slotNum;
    Image img;
    public Item item { get; set; }  // Item�� �����ϴ� ����



    void Start()
    {
        img = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //����;
        if (GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] != null)
        {
            Debug.Log("����");
            if (InventoryUI.Instance.goons.EquipItem(GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum],slotNum))
            {
                GameManager.instance.storage[eventData.pointerDrag.gameObject.GetComponent<InventorySlot>().slotNum] = null;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //����;
    }
    // Update is called once per frame
    void Update()
    {
        if (InventoryUI.Instance.goons != null)
        {
            if (InventoryUI.Instance.goons.items[slotNum] != null)
            {
                img.sprite = InventoryUI.Instance.goons.items[slotNum].sprite;
                item = InventoryUI.Instance.goons.items[slotNum];
            }
            else
            {
                img.sprite = null;
               // item = null;

            }
        }
    }

}
