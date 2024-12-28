    using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class RoomLight : MonoBehaviour
{
    Light2D light;
    bool onoff = false;

    void Start()
    {
        light = GetComponent<Light2D>();
    }

   IEnumerator LightsOn()
    {
        if (onoff == false)
        {
            onoff = true;
            while (light.intensity <= 1.99f)
            {
                light.intensity = Mathf.SmoothStep(light.intensity, 2, 0.03f);
                yield return null;
            }
            light.intensity = 2;
        }
        yield break;
    }
    
    // Trigger에 들어올 때 실행될 메서드
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!onoff)
        {
            StartCoroutine(LightsOn());
        }
    }


}
