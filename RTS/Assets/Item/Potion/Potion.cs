using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PotionBase", menuName = "Potion/PotionBase")]
public class Potion : ScriptableObject, Iitem
{
    [field: SerializeField] public Sprite sprite { get; set; }
    [field: SerializeField] public string itemname { get; set; }
    public string description;
    public List<ScriptableObject> potions;

    public void onUse(Goons goons)
    {
        Debug.Log(goons);
        foreach (var item in potions)
        {
            IPotion potion = item as IPotion;
            potion.onUse(goons);
        }  

        Destroy(this);
    }

    public string getDesc()
    {
        return description;
    }
}
