using UnityEngine;
using UnityEngine.UI;
public class InventoryDragSlot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static InventoryDragSlot instance;
    public InventorySlot dragSlot;

    [SerializeField]
    private Image imageItem;

    void Start()
    {
        instance = this;
        imageItem = GetComponent<Image>();
    }

    public void DragSetImage(Image _itemImage)
    {
        imageItem.sprite = _itemImage.sprite;
        SetColor(0.7f);
    }

    public void SetColor(float _alpha)
    {
        Color color = imageItem.color;
        color.a = _alpha;
        imageItem.color = color;
    }
}
