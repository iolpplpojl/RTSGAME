using UnityEngine;

public class CameraFinder : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        UICameraManager.instance.can.worldCamera = cam;
    }
}
