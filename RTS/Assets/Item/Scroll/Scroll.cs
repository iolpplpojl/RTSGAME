using UnityEngine;
[CreateAssetMenu(fileName = "BaseScroll", menuName = "Scrolls/BaseScroll")]

public class Scroll : ScriptableObject, Iitem
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [field: SerializeField] public Sprite sprite { get; set; }
    [field: SerializeField] public string itemname { get; set; }
    public string description;
    public GameObject magic;

    public string getDesc()
    {
        return description;
    }

    public void use(int slot)
    { 
        var temp = Instantiate(magic);
        temp.GetComponent<Magic>().slotNum = slot;
    }


}