using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goons : MonoBehaviour,IGoons
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool Selected;

    [SerializeField]
    private List<GameObject> _members  = new List<GameObject>();
    public List<GameObject> members { get; set; } = new List<GameObject>();


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
                    obj.GetComponent<Player>().SetMoveDirection(temp.GetComponentInParent<IGoons>().SetTargeting());
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
                    float radius = Mathf.Sqrt(i) * (GetComponentInChildren<NavMeshAgent>().radius * 1.44f);

                    float x = Mathf.Cos(angle) * radius;
                    float y = Mathf.Sin(angle) * radius;
                    var temps = obj.GetComponent<Player>();

                    temps.SetMoveDirection(pos + new Vector2(x,y));
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
            Destroy(gameObject);
        }


    }
}
