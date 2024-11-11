using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PotionBase", menuName = "Potion/PotionBase")]
public class Potion : ScriptableObject
{
    public Sprite sprite;
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
}
