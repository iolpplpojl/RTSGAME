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
            temp += string.Format("�ִ� ü���� {0} ������ŵ�ϴ�.\n", Health);
        }
        if (Power != 0)
        {
            temp += string.Format("������ {0} ������ŵ�ϴ�.\n", Power);
        }
        if (Defence != 0)
        {
            temp += string.Format("�� {0} ������ŵ�ϴ�.\n", Defence);
        }
        if (Damage != 0)
        {
            temp += string.Format("���ط��� {0} ������ŵ�ϴ�.\n", Damage);
        }
        temp += string.Format("{0}���� Ž������ ���ӵ˴ϴ�.\n", Duration);
        return temp;
    }
}
