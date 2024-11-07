using UnityEngine;

[CreateAssetMenu(fileName = "DamageITem", menuName = "Items/AddDamage")]
public class Item_AddDamage : ScriptableObject,IEffect
{
    public int addDamage;
    public  void onAttack(Player player, IDamage enemy)
    {
        Debug.Log("�߰� ����!!!");
        enemy.TakeDamage(GameManager.instance.Dice(1,addDamage));
    }

    public  void onHit(){
        return;
    }
}
