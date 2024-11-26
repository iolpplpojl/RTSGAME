using UnityEngine;
[CreateAssetMenu(fileName = "BaseScroll", menuName = "Scrolls/BaseScroll")]

public class Scroll : ScriptableObject, Iitem
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [field: SerializeField] public Sprite sprite { get; set; }
    [field: SerializeField] public string itemname { get; set; }
    public string description;

    public string getDesc()
    {
        return description;
    }



}
