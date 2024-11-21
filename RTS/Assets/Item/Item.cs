using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "BaseItem", menuName = "Items/BaseItem")]
public class Item : ScriptableObject,Iitem
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int Health;
    public int Power;
    public int Damage;
    public int Defence;
    [field: SerializeField] public Sprite sprite { get; set; }
    [field: SerializeField] public string itemname { get; set; }
    public string description;
    public List<ScriptableObject> effect;
    public int rare;

    public virtual void Equip(Player player)
    {
        player.addHealth += Health;
        player.Heal(Health);
        player.addPower += Power;
        player.addDamage += Damage;
        player.addDefence += Defence;
        Debug.Log(player + "�����Ϸ�");
    }
    public virtual void UnEquip(Player player)
    {
        player.addHealth -= Health;
        player.Heal(0);
        player.addPower -= Power;
        player.addDamage -= Damage;
        player.addDefence -= Defence;
        Debug.Log(player + "�����Ϸ�");
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
                temp += string.Format("ü�� + {0}\n", Health);
            }
            else
            {
                temp += string.Format("ü�� - {0}\n", Math.Abs(Health));

            }
        }

        if (Power != 0)
        {
            if (Power > 0)
            {
                temp += string.Format("���� + {0}\n", Power);
            }
            else
            {
                temp += string.Format("���� - {0}\n", Math.Abs(Power));

            }
        }
        if (Damage != 0)
        {
            if (Damage > 0)
            {
                temp += string.Format("���ط� + {0}\n", Damage);
            }
            else
            {
                temp += string.Format("���ط� - {0}\n", Math.Abs(Damage));

            }
        }
        if (Defence != 0)
        {
            if (Defence > 0)
            {
                temp += string.Format("��� + {0}\n", Defence);
            }
            else
            {
                temp += string.Format("��� - {0}\n", Math.Abs(Defence));

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
