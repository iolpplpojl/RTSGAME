using System.Collections.Generic;
using UnityEngine;

public class EnemyGoons : MonoBehaviour,IGoons
{
    [SerializeField]
    private List<GameObject> _members = new List<GameObject>();
    public List<GameObject> members { get; set; } = new List<GameObject>();
    public List<ChestData> chest;

    bool droped = false;

    public void memberDie(GameObject member)
    {
        members.Remove(member);
        Destroy(member);
        if (members.Count == 0)
        {
            Debug.Log(chest+ "»óÀÚ");
            if(chest != null && droped == false)
            {
                var temp = Instantiate(ItemDatabase.instance.Chest, transform.position, Quaternion.identity, transform.parent);
                temp.GetComponent<Chest>().slot = chest;
                droped = true;
            }
            transform.GetComponentInParent<DungeonManager>().GoonsDie(this);
            Destroy(gameObject);
        }
    }

    public GameObject SetTargeting()
    {
        return members[Random.Range(0, members.Count)];
    }


    public void setMove(GameObject Target)
    {
        foreach(var member in members)
        {
            member.GetComponentInChildren<Enemy>().SetTarget(Target);
        }
    }

    void Start()
    {
        transform.GetComponentInParent<DungeonManager>().GoonsSpawn(this);

        members = _members;
        var temp = transform.childCount;
        for (int i = 0; i < temp; i++)
        {
            members.Add(transform.GetChild(i).GetChild(0).gameObject);
        }
    }

}
