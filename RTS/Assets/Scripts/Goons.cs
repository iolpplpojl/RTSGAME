using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Goons : MonoBehaviour,IGoons
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject face;
    public bool Selected;

    [SerializeField]
    private List<GameObject> _members  = new List<GameObject>();
    public List<GameObject> members { get; set; } = new List<GameObject>();
    public List<Item> items = new List<Item>();
    public List<Buff> buffs = new List<Buff>();

    public int ItemCount = 2;
    int NowEquip = 0;
    public string Name;
    
    
    
    public GameObject SetTargeting()
    {
        return members[Random.Range(0, members.Count)];
    }

    void Start()
    {
        members = _members;
        var temp = transform.childCount;
        for(int i = 0; i < temp; i++)
        {
            members.Add(transform.GetChild(i).gameObject);
        }

        for(int i = 0; i < ItemCount; i++)
        {
            items.Add(null);
        }
    }
    
    public bool usePotion(Potion potions)
    {
        Potion _item = Instantiate(potions);
        _item.onUse(this);
        return true;
    }
    public void setMove()
    {
        foreach (var member in members)
        {
            member.GetComponentInChildren<Player>().SetAggresive();
        }
    }
    public void getBuff(Buff buff)
    {
        buffs.Add(buff);
        foreach(GameObject obj in members)
        {
            var player = obj.GetComponentInChildren<Player>();
            player.addHealth += buff.Health;
            player.addPower += buff.Power;
            player.addDamage += buff.Damage;
            player.addDefence += buff.Defence;
        }
    }
    public void deBuff(Buff buff)
    {
        foreach (GameObject obj in members)
        {
            var player = obj.GetComponentInChildren<Player>();
            player.addHealth -= buff.Health;
            player.addPower -= buff.Power;
            player.addDamage -= buff.Damage;
            player.addDefence -= buff.Defence;
        }
        buffs.Remove(buff);
    }


    public bool EquipItem(Item item, int slot)
    {

            Item _item = Instantiate(item);
            foreach (var member in members)
            {
                _item.Equip(member.transform.GetChild(0).GetComponent<Player>());
            }
            items[slot] = _item;
            NowEquip++;
            return true;

 //           Debug.Log("장비 꽉참");
 //           return false;
 
    }
    public bool EquipItem(Item item)
    {
        if (NowEquip < ItemCount)
        {
            Item _item = Instantiate(item);
            foreach (var member in members)
            {
                _item.Equip(member.transform.GetChild(0).GetComponent<Player>());
            }
            items[NowEquip] = _item;
            NowEquip++;
            return true;
        }
        else
        {
            Debug.Log("장비 꽉참");
            return false;
        }
    }
    public void RemoveItem(int pos)
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1) && Selected)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var temp = Physics2D.OverlapCircle(pos, 0.15f, LayerMask.GetMask("Enemy"));
            if (temp) {
                foreach (GameObject obj in members)
                {
                    Player player = obj.transform.GetChild(0).GetComponent<Player>();
                    if (player != null)
                    {
                        // temp 객체에서 IGoons 컴포넌트를 찾고 SetTargeting 호출
                        IGoons goons = temp.GetComponentInParent<IGoons>();
                        if (goons != null)
                        {
                            player.SetMoveDirection(goons.SetTargeting());
                        }
                    }
                }
            }
            else
            {
                Debug.Log(pos);
                int i = 0;

                foreach (GameObject obj in members)
                { 
                    // x, y 위치를 원형으로 설정
                    float angle = i * 137.5f * Mathf.Deg2Rad;
                    float radius = Mathf.Sqrt(i) * (obj.transform.GetChild(0).GetComponent<NavMeshAgent>().radius * 1.44f);
                    float x = Mathf.Cos(angle) * radius;
                    float y = Mathf.Sin(angle) * radius;
                    var temps = obj.transform.GetChild(0).GetComponent<Player>();
                    temps.SetMoveDirection(pos + new Vector2(x, y));
                    i++;
                }
            
            }
        }


    }


    public void memberDie(GameObject member)
    {
        members.Remove(member);
        Destroy(member);
        if (members.Count == 0)
        {
            GetComponentInParent<GoonsManager>().Goons.Remove(this);
            GetComponentInParent<GoonsManager>().Setup();

            Destroy(gameObject);
        }


    }
}
