using UnityEngine;
[CreateAssetMenu(fileName = "HealItem", menuName = "Items/AttackHeal")]
public class Item_AttackHeal : ScriptableObject,IEffect
{
    public int Heal;
    public  void onAttack(Player player, IDamage enemy)
    {
        Debug.Log("��!!!");
        player.Health += Heal;
    }

    public  void onHit()
    {
        return;
    }
}
