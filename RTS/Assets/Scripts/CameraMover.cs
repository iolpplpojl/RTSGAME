using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public static CameraMover instance;
    Camera cam;
    public DungeonManager nowDungeon;
    [Range(1, 100)]
    public float cameraSpeed = 20;
    [Range(1, 200)]

    public float screenSizeTickness = 10;

    [Range(0f, 1f)]
    public float smoothingStat = 1f;
    public Vector3 velocity = Vector3.zero;
  
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        cam = GetComponent<Camera>();
    }
    // Update is called once per f  rame
    void Update()
    {

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float clampCam = cam.orthographicSize;
        if (scroll < 0)
        {
            clampCam = cam.orthographicSize += 0.1f;
        }
        else if (scroll > 0)
        {
            clampCam = cam.orthographicSize -= 0.1f;
        }

        cam.orthographicSize = Mathf.Clamp(clampCam, nowDungeon.min.y, nowDungeon.max.y); // 12 
        Vector3 pos = transform.position;

        if (Input.mousePosition.x >= Screen.width - screenSizeTickness || Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += cameraSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x <= screenSizeTickness || Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= cameraSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y >= Screen.height - screenSizeTickness || Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += cameraSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= screenSizeTickness || Input.GetKey(KeyCode.DownArrow))
        {
            pos.y -= cameraSpeed * Time.deltaTime;
        }

        // Orthographic 카메라의 높이는 size 속성에 의해 결정됩니다.
        float height = cam.orthographicSize * 2;

        // 화면의 너비는 화면 비율(aspect ratio)을 사용하여 계산할 수 있습니다.
        float width = height * cam.aspect;

        float clampedX = Mathf.Clamp(pos.x, nowDungeon.min.x + width/2, nowDungeon.max.x - width/2);
        float clampedY = Mathf.Clamp(pos.y, nowDungeon.min.y + height/2, nowDungeon.max.y - height/2);
        pos.x = clampedX;
        pos.y = clampedY;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothingStat);
    }
}