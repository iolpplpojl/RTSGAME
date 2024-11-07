using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Item : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int Health;
    public int Power;
    public int Damage;
    public int Defence;
    public Sprite sprite;

    public virtual void Equip(Player player)
    {
        player.Health += Health;
        player.Power += Power;
        player.Damage += Damage;
        player.Defence += Defence;
        Debug.Log(player + "장착완료");
    }
    public virtual void UnEquip(Player player)
    {
        player.Health -= Health;
        player.Power -= Power;
        player.Damage -= Damage;
        player.Defence -= Defence;
        Debug.Log(player + "해제완료");
    }

    public abstract void onAttack(Player player, IDamage enemy);

    public abstract void onHit();
}
