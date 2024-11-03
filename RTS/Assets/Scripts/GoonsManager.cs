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
        var temp = isNumberKeyPressed();
        if (temp != -1)
        {
            Select(temp);
        }

    }


    int isNumberKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            return 0;
        }
        for (KeyCode key = KeyCode.Alpha1; key <= KeyCode.Alpha9; key++)
        {
            if (Input.GetKeyDown(key))
            {
                return key - KeyCode.Alpha0;
            }
        }
        return -1;
    }

    void Select(int idx)
    {
        Debug.Log(idx);
        if(idx == 0)
        {
            idx = 10;
        }
        if(idx > Goons.Count)
        {
            return;
        }
        for (int i = 0; i < Goons.Count; i++)
        {
            if(i == idx-1)
            {
                Goons [i].Selected = true;
            }
            else
            {
                Goons[i].Selected = false;
            }
                
        }
    }
}
