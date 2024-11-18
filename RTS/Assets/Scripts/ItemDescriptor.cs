using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDescriptor : MonoBehaviour
{
    public static ItemDescriptor instance;

    public Item item;
    public Vector3 size;
    RectTransform rect;
    public TMP_Text title;
    public TMP_Text desc;
    public Image sprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            gameObject.SetActive(false);
        }   

        rect = GetComponent<RectTransform>();

    }

    public void SetUP(Item item)
    {
        float screenRatio = (float)Screen.width / 1920;
        float screenRatioy = (float)Screen.height / 1080;
        size = new Vector3(-(rect.rect.size.x / 2 * screenRatio), rect.rect.size.y / 2 * screenRatioy, 0); // = 16:9
        Debug.Log(size);
        title.text = item.itemname;
        desc.text = item.description;
        sprite.sprite = item.sprite;
    }
}
