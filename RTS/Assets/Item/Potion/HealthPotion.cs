using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HealthUp", menuName = "Potion/HealthUP")]
public class HealthPotion : ScriptableObject, IPotion
{
    public int amount;
    public void onUse(Goons goons)
    {
        foreach(var player in goons.members)
        {
            player.GetComponentInChildren<Player>().Heal(amount);
        }
    }
}
