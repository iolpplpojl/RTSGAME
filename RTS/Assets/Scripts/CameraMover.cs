using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Range(1, 100)]
    public float cameraSpeed = 20;
    [Range(1, 200)]

    public float screenSizeTickness = 10;

    [Range(0f, 1f)]
    public float smoothingStat = 1f;
    public Vector3 velocity = Vector3.zero;
    // Update is called once per f  rame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.mousePosition.x >= Screen.width - screenSizeTickness)
        {
            pos.x += cameraSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x <= screenSizeTickness)
        {
            pos.x -= cameraSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y >= Screen.height - screenSizeTickness)
        {
            pos.y += cameraSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= screenSizeTickness)
        {
            pos.y -= cameraSpeed * Time.deltaTime;
        }
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothingStat);
    }
}