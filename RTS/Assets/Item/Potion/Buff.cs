using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
[CreateAssetMenu(fileName = "Buff", menuName = "Buffs/BaseBuff")]

public class Buff : ScriptableObject, IBuff
{
    [field: SerializeField] public int Duration { get; set; }

    public float Health;
    public float Damage;
    public int Defence;
    public int Power;


    public void AddBuff(Goons goons)
    {
        var temp = Instantiate(this);
        goons.getBuff(temp);
    }
    public void DeBuff(Goons goons)
    {
        goons.deBuff(this);
    }
    public string getDesc()
    {
        string temp = "";
        if(Health != 0)
        {
            temp += string.Format("최대 체력을 {0} 증가시킵니다.\n", Health);
        }
        if (Power != 0)
        {
            temp += string.Format("공격을 {0} 증가시킵니다.\n", Power);
        }
        if (Defence != 0)
        {
            temp += string.Format("방어를 {0} 증가시킵니다.\n", Defence);
        }
        if (Damage != 0)
        {
            temp += string.Format("피해량을 {0} 증가시킵니다.\n", Damage);
        }
        temp += string.Format("{0}번의 탐색동안 지속됩니다.\n", Duration);
        return temp;
    }
}
