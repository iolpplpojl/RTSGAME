using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //��������Ʈ���� �ھƳֱ�
    //Start��, ������ ���� ��Ÿ��� �ϰ� ����->
    GameObject enemy;
    public int rank;
    void Awake()
    {
        GetComponentInParent<DungeonManager>().enemyspawnpos.Add(this);
        enemy = ItemDatabase.instance.GetEnemyGoons(rank);

    }
    public void setUp(int times)
    {
        if(times == 0)
        {
            Spawn();
        }
        else if (GameManager.instance.SpawnerRandom.Range(0f,1f) > 0.3f)
        {
            Spawn();
        }
    }



    void Spawn()
    {
        var temp = Instantiate(enemy, transform.position, Quaternion.identity, transform.parent);
        temp.GetComponent<EnemyGoons>().chest = ItemDatabase.instance.GetRandomChestData(rank); 
    }
}
