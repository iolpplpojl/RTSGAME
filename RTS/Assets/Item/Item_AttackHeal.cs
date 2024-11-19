using UnityEngine;
[CreateAssetMenu(fileName = "HealItem", menuName = "Items/AttackHeal")]
public class Item_AttackHeal : ScriptableObject,IEffect
{
    public int Heal;
    public  void onAttack(Player player, IDamage enemy)
    {
        Debug.Log("힐!!!");
        player.Heal(Heal);
    }
    public void onUpdate(Player player)
    {
        return;
    }
    public  void onHit()
    {
        return;
    }
    public string desc;
    public string getDesc()
    {
        return string.Format("공격 적중시 {0}의 체력을 회복합니다.",Heal);
    }
}
