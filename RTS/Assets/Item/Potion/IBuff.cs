using UnityEngine;

public interface IBuff
{
    public int Duration { get; set; }
    public void AddBuff(Goons goons);
    public void DeBuff(Goons goons);
}
