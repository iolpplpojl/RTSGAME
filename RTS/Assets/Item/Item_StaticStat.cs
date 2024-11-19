using System.Diagnostics;
using UnityEngine;
[CreateAssetMenu(fileName = "HealItem", menuName = "Items/StaticStat")]

public class Item_StaticStat : ScriptableObject, IEffect
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Flags]  // [Flags] �Ӽ��� �߰��Ͽ� ��Ʈ ������ �����ϰ� �մϴ�.
    public enum ItemType
    {
        NONE = 0,
        ���ݷ� = 1 << 0,  // 1 (0001)
        ���� = 1 << 1,   // 2 (0010)
        ü�� = 1 << 2,  // 4 (0100)
        ����� = 2 << 3,

    }

    public ItemType type;
    public int value;
    public void onAttack(Player player, IDamage enemy)
    {
        return;
    }
    public void onUpdate(Player player)
    {
        if(type.HasFlag(ItemType.���ݷ�))
        {
            player.Power = value;
        }
        if(type.HasFlag(ItemType.����))
        {
            player.Defence = value;
        }
        if(type.HasFlag(ItemType.ü��))
        {
            player.Health = value;
        }
        if(type.HasFlag(ItemType.�����))
        {
            player.Damage = value;
        }
    }
    public void onHit()
    {
        return;
    }
    public string desc;
    public string getDesc()
    {
        return desc;
    }
}
