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
        // 타일맵의 bounds (셀 좌표 기준)
        BoundsInt tilemapBounds = map.cellBounds;

        // 타일맵의 월드 공간에서의 크기 계산
        Vector3 tilemapWorldSize = new Vector3(
            tilemapBounds.size.x * map.cellSize.x,
            tilemapBounds.size.y * map.cellSize.y,
            0);

        // 타일맵의 위치 (월드 좌표)
        Vector3 tilemapWorldPosition = map.transform.position;

        // 카메라의 뷰포트 크기 계산
        float cameraHeight = cam.orthographicSize * 2;
        float cameraWidth = cameraHeight * cam.aspect;

        // 카메라의 월드 좌표 (카메라의 중심)
        Vector3 cameraPosition = cam.transform.position;

        // 타일맵의 경계 (좌측 하단과 우측 상단)
        Vector3 tilemapMin = tilemapWorldPosition - tilemapWorldSize / 2;
        Vector3 tilemapMax = tilemapWorldPosition + tilemapWorldSize / 2;

        // 카메라가 타일맵의 왼쪽, 오른쪽, 위, 아래 경계에 있는지 확인  
        bool isAtLeftEdge = cameraPosition.x - cameraWidth / 2 <= tilemapMin.x;
        bool isAtRightEdge = cameraPosition.x + cameraWidth / 2 >= tilemapMax.x;
        bool isAtBottomEdge = cameraPosition.y - cameraHeight / 2 <= tilemapMin.y;
        bool isAtTopEdge = cameraPosition.y + cameraHeight / 2 >= tilemapMax.y;
        Debug.Log(cameraPosition.x + " " +  cameraWidth / 2 + " " + tilemapMin.x);

        // 카메라가 타일맵의 가장자리에 있는지 여부 반환
        return isAtLeftEdge || isAtRightEdge || isAtBottomEdge || isAtTopEdge;
    }
}
