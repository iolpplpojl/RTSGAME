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

    public List<GameObject> Goons = new List<GameObject>();
    public List<EnemyGoons> remaingoons = new List<EnemyGoons>();
    public List<Transform> spawnpos = new List<Transform>();
    public List<EnemySpawner> enemyspawnpos = new List<EnemySpawner>();

  //  public List<GameObject> enemy;

    public string description;

    List<GameObject> spawned;

    void Start()
    {
        map = GetComponentInChildren<Tilemap>();
        map.RefreshAllTiles();
        map.CompressBounds();
        CameraMover.instance.nowDungeon = this;
        IsCameraAtTilemapEdge();
        Debug.Log(map);
        if(description != null)
        {
            AlertManager.instance.Append(description);
        }
    }
    public void SpawnEnemy()
    {
        int times = 0;
        Debug.Log(Goons.Count + " 스폰중");
        foreach(EnemySpawner n in enemyspawnpos)
        {
            n.setUp(times, Goons[times]);
            times++;
        }
    }
    public void GoonsSpawn(EnemyGoons goons)
    {
        remaingoons.Add(goons);
      
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
        return false;
    }
}
