using UnityEngine;

public interface IEffect
{
    public  void onAttack(Player player, IDamage enemy);
    public  void onHit();
}
