using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //스폰포인트마다 박아넣기
    //Start시, 아이템 설정 기타등등 하고 생성->
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
