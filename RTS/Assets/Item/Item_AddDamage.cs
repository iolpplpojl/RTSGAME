using UnityEngine;

public class Item_AddDamage : Item
{
    public int addDamage;
    public override void onAttack(Player player, IDamage enemy)
    {
        Debug.Log("�߰� ����!!!");
        enemy.TakeDamage(GameManager.instance.Dice(1,Damage));
    }

    public override void onHit(){
        return;
    }
}
