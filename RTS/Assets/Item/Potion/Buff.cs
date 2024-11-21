using System.Collections.Generic;
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

    }
}
