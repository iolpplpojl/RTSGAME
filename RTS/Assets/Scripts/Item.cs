using UnityEngine;

public abstract class Item : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int Health;
    public int Power;
    public int Damage;
    public int Defence;

    public virtual void Equip(Player player)
    {
        player.Health += Health;
        player.Power += Power;
        player.Damage += Damage;
        player.Defence += Defence;
        Debug.Log(player + "ÀåÂø¿Ï·á");
    }
    public virtual void UnEquip(Player player)
    {

    }

}
