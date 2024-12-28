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
            Instantiate(enemy, transform.position, Quaternion.identity, transform.parent);
        }
        else if (GameManager.instance.SpawnerRandom.Range(0f,1f) > 0.3f)
        {
            Instantiate(enemy, transform.position, Quaternion.identity, transform.parent);
        }
    }
}
