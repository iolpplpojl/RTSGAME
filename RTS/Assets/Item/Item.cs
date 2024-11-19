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
    public string itemname;
    public string description;
    public List<ScriptableObject> effect;
    public int rare;

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
    public void onUpdate(Player player)
    {
        foreach (var item in effect)
        {
            IEffect _effect = item as IEffect;
            _effect.onUpdate(player);
        }
    }

    public void onHit()
    {

    }

    public string getDesc()
    {
        string temp = "";
        if(Health != 0)
        {
            if (Health > 0)
            {
                temp += string.Format("체력 + {0}\n", Health);
            }
            else
            {
                temp += string.Format("체력 - {0}\n", Math.Abs(Health));

            }
        }

        if (Power != 0)
        {
            if (Power > 0)
            {
                temp += string.Format("공격 + {0}\n", Power);
            }
            else
            {
                temp += string.Format("공격 - {0}\n", Math.Abs(Power));

            }
        }
        if (Damage != 0)
        {
            if (Damage > 0)
            {
                temp += string.Format("피해량 + {0}\n", Damage);
            }
            else
            {
                temp += string.Format("피해량 - {0}\n", Math.Abs(Damage));

            }
        }
        if (Defence != 0)
        {
            if (Defence > 0)
            {
                temp += string.Format("방어 + {0}\n", Defence);
            }
            else
            {
                temp += string.Format("방어 - {0}\n", Math.Abs(Defence));

            }
        }

        foreach (var item in effect)
        {
            IEffect _effect = item as IEffect;
            temp += _effect.getDesc();
            temp += "\n";
        }
        temp += description;
        return temp;
    }



}
