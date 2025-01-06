using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //스폰포인트마다 박아넣기
    //Start시, 아이템 설정 기타등등 하고 생성->
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
