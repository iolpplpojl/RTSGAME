using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class DungeonManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Tilemap map;
    Camera cam;
    public Vector3 min;
    public Vector3 max;
    public List<EnemyGoons> remaingoons = new List<EnemyGoons>();
    public List<Transform> spawnpos;
    public List<Transform> enemyspawnpos;

    public List<GameObject> enemy;

    List<GameObject> spawned;

    void Start()
    {
        map = GetComponentInChildren<Tilemap>();
        map.RefreshAllTiles();
        map.CompressBounds();
        CameraMover.instance.nowDungeon = this;
        IsCameraAtTilemapEdge();
        Debug.Log(map);
        GameManager.instance.resetDungeon(this);
        
    }
    public void SpawnEnemy()
    {
        foreach(var temp in enemy)
        {
            if (enemyspawnpos.Count > 0)
            {
                Transform pos = enemyspawnpos[Random.Range(0, enemyspawnpos.Count)];

                remaingoons.Add(Instantiate(temp, pos.position, Quaternion.identity, transform).GetComponent<EnemyGoons>());
                enemyspawnpos.Remove(pos);
                Debug.Log("적 생성됨.");
            }
            }
        }

    public void GoonsDie(EnemyGoons goons)
    {
        remaingoons.Remove(goons);
        if(remaingoons.Count == 0)
        {
            GameManager.instance.DungeonClear();
        }
    }
    public bool IsCameraAtTilemapEdge()
    {

        // Tilemap의 경계 구하기
        BoundsInt bounds = map.cellBounds;

        // 타일 크기 구하기
        Vector3 tileSize = map.cellSize;

        // 타일맵의 월드 공간 크기 계산
        Vector3 worldSize = new Vector3(bounds.size.x * tileSize.x, bounds.size.y * tileSize.y, 0f);


        Vector3 tilemapWorldPosition = transform.position;


        min = bounds.min; //tilemapWorldPosition - worldSize / 2;
        max = bounds.max; //tilemapWorldPosition + worldSize / 2;
        Debug.Log(" + " + tileSize);
        Debug.Log("min: " + min);
        Debug.Log("max " + max);
        Debug.Log("size " + worldSize);
        Debug.Log("bound" + bounds);
        return false;
    }
}
