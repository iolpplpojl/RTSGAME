using UnityEngine;
[CreateAssetMenu(fileName = "PotionBuff", menuName = "Potion/Buff")]

public class BuffPotion : ScriptableObject, IPotion
{
    public Buff buff;
    public void onUse(Goons goons)
    {
        buff.AddBuff(goons);
    }
}
