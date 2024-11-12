using UnityEngine;
using UnityEngine.Tilemaps;
public class DungeonManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Tilemap map;
    Camera cam;
    void Start()
    {
        map = GetComponentInChildren<Tilemap>();
        cam = Camera.main;
        BoundsInt bounds = map.cellBounds;
        Vector3 size = new Vector3(bounds.size.x * map.cellSize.x, bounds.size.y * map.cellSize.y, 0);

        Vector3 worldSize = map.transform.TransformVector(size);

        Debug.Log("Tilemap World Size: " + worldSize);
        Debug.Log("Tilemap bounds Size: " + bounds);
    }

    void Update()
    {
        if (IsCameraAtTilemapEdge())
        {
            Debug.Log("Camera is at the edge of the Tilemap!");
        }
        else
        {
            Debug.Log("Camera is not at the edge of the Tilemap.");
        }
    }

    bool IsCameraAtTilemapEdge()
    {
        // Ÿ�ϸ��� bounds (�� ��ǥ ����)
        BoundsInt tilemapBounds = map.cellBounds;

        // Ÿ�ϸ��� ���� ���������� ũ�� ���
        Vector3 tilemapWorldSize = new Vector3(
            tilemapBounds.size.x * map.cellSize.x,
            tilemapBounds.size.y * map.cellSize.y,
            0);

        // Ÿ�ϸ��� ��ġ (���� ��ǥ)
        Vector3 tilemapWorldPosition = map.transform.position;

        // ī�޶��� ����Ʈ ũ�� ���
        float cameraHeight = cam.orthographicSize * 2;
        float cameraWidth = cameraHeight * cam.aspect;

        // ī�޶��� ���� ��ǥ (ī�޶��� �߽�)
        Vector3 cameraPosition = cam.transform.position;

        // Ÿ�ϸ��� ��� (���� �ϴܰ� ���� ���)
        Vector3 tilemapMin = tilemapWorldPosition - tilemapWorldSize / 2;
        Vector3 tilemapMax = tilemapWorldPosition + tilemapWorldSize / 2;

        // ī�޶� Ÿ�ϸ��� ����, ������, ��, �Ʒ� ��迡 �ִ��� Ȯ��  
        bool isAtLeftEdge = cameraPosition.x - cameraWidth / 2 <= tilemapMin.x;
        bool isAtRightEdge = cameraPosition.x + cameraWidth / 2 >= tilemapMax.x;
        bool isAtBottomEdge = cameraPosition.y - cameraHeight / 2 <= tilemapMin.y;
        bool isAtTopEdge = cameraPosition.y + cameraHeight / 2 >= tilemapMax.y;
        Debug.Log(cameraPosition.x + " " +  cameraWidth / 2 + " " + tilemapMin.x);

        // ī�޶� Ÿ�ϸ��� �����ڸ��� �ִ��� ���� ��ȯ
        return isAtLeftEdge || isAtRightEdge || isAtBottomEdge || isAtTopEdge;
    }
}
