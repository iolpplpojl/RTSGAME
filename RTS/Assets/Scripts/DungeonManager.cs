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


    void Start()
    {
        map = GetComponentInChildren<Tilemap>();
        map.RefreshAllTiles();
        map.CompressBounds();
        CameraMover.instance.nowDungeon = this;
        IsCameraAtTilemapEdge();
        Debug.Log(map);
        foreach (var temp in GetComponentsInChildren<EnemyGoons>())
        {
            remaingoons.Add(temp);
        }

    }

    public bool IsCameraAtTilemapEdge()
    {

        // Tilemap�� ��� ���ϱ�
        BoundsInt bounds = map.cellBounds;

        // Ÿ�� ũ�� ���ϱ�
        Vector3 tileSize = map.cellSize;

        // Ÿ�ϸ��� ���� ���� ũ�� ���
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
