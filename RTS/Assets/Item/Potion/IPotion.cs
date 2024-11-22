using UnityEngine;

public interface IPotion
{
    public void onUse(Goons goons);
    public string getDesc();
}
