using UnityEngine;

[CreateAssetMenu(fileName = "DamageITem", menuName = "Items/AddDamage")]
public class Item_AddDamage : ScriptableObject,IEffect
{
    public int addDamage;
    public string desc;
    public  void onAttack(Player player, IDamage enemy)
    {
        Debug.Log("추가 피해!!!");
        enemy.TakeDamage(GameManager.instance.Dice(1,addDamage));
    }
    public void onUpdate(Player player)
    {
        return;
    }
    public  void onHit(){
        return;
    }
    public string getDesc()
    {
        return string.Format("공격 적중시 추가로 공격해 피해량을 1d{0} 입힙니다.",addDamage);
    }
}
