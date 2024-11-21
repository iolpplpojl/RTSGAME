using System.Collections.Generic;
using UnityEngine;

public class EnemyGoons : MonoBehaviour,IGoons
{
    [SerializeField]
    private List<GameObject> _members = new List<GameObject>();
    public List<GameObject> members { get; set; } = new List<GameObject>();
    public GameObject chest;


    public void memberDie(GameObject member)
    {
        members.Remove(member);
        Destroy(member);
        if (members.Count == 0)
        {
            if(chest != null)
            {
                var temp = Instantiate(chest, transform.position, Quaternion.identity, transform.parent);
            }
            transform.parent.GetComponent<DungeonManager>().GoonsDie(this);
            Destroy(gameObject);
        }
    }

    public GameObject SetTargeting()
    {
        return members[Random.Range(0, members.Count)];
    }

    void Start()
    {
        members = _members;
        var temp = transform.childCount;
        for (int i = 0; i < temp; i++)
        {
            members.Add(transform.GetChild(i).gameObject);
        }
    }

}
