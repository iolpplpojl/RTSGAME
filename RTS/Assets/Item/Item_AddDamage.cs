using UnityEngine;

[CreateAssetMenu(fileName = "DamageITem", menuName = "Items/AddDamage")]
public class Item_AddDamage : ScriptableObject,IEffect
{
    public int addDamage;
    public string desc;
    public  void onAttack(Player player, IDamage enemy)
    {
        Debug.Log("�߰� ����!!!");
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
        return string.Format("���� ���߽� �߰��� ������ ���ط��� 1d{0} �����ϴ�.",addDamage);
    }
}
