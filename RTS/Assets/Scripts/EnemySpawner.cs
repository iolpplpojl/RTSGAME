using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //��������Ʈ���� �ھƳֱ�
    //Start��, ������ ���� ��Ÿ��� �ϰ� ����->
    public GameObject enemy;
    public int rank;
    void Awake()
    {
        GetComponentInParent<DungeonManager>().enemyspawnpos.Add(this);
    }
    public void setUp(int times, GameObject enemy)
    {
        this.enemy = enemy;
        Spawn();
    }



    void Spawn()
    {
        var temp = Instantiate(enemy, transform.position, Quaternion.identity, transform.parent);
        temp.GetComponent<EnemyGoons>().chest = ItemDatabase.instance.GetRandomChestData(0);

    }
}
