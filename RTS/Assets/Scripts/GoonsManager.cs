using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoonsManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    List<Goons> Goons = new List<Goons>();
    void Start()
    {
        var temp = transform.childCount;
        for (int i = 0; i < temp; i++)
        {
            Goons.Add(transform.GetChild(i).gameObject.GetComponent<Goons>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Goons[0].Selected = true;
        }
    }
}
