using UnityEngine;

public interface IEffect
{
    public  void onAttack(Player player, IDamage enemy);
    public  void onHit();
    public void onUpdate(Player player);
    public string getDesc();

}
