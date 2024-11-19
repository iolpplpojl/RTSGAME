using System.Diagnostics;
using UnityEngine;
[CreateAssetMenu(fileName = "HealItem", menuName = "Items/StaticStat")]

public class Item_StaticStat : ScriptableObject, IEffect
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Flags]  // [Flags] 속성을 추가하여 비트 연산을 가능하게 합니다.
    public enum ItemType
    {
        NONE = 0,
        공격력 = 1 << 0,  // 1 (0001)
        방어력 = 1 << 1,   // 2 (0010)
        체력 = 1 << 2,  // 4 (0100)
        대미지 = 2 << 3,

    }

    public ItemType type;
    public int value;
    public void onAttack(Player player, IDamage enemy)
    {
        return;
    }
    public void onUpdate(Player player)
    {
        if(type.HasFlag(ItemType.공격력))
        {
            player.Power = value;
        }
        if(type.HasFlag(ItemType.방어력))
        {
            player.Defence = value;
        }
        if(type.HasFlag(ItemType.체력))
        {
            player.Health = value;
        }
        if(type.HasFlag(ItemType.대미지))
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
