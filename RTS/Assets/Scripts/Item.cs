using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "BaseItem", menuName = "Items/BaseItem")]
public class Item : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int Health;
    public int Power;
    public int Damage;
    public int Defence;
    public Sprite sprite;
    public List<ScriptableObject> effect;

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
    public void onAttack(Player player, IDamage enemy)
    {
        foreach (var item in effect)
        {
            IEffect _effect = item as IEffect;
            _effect.onAttack(player, enemy);
        }
    }
}
