using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GoonsManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public List<Goons> Goons = new List<Goons>();
    public List<GameObject> SelectField = new List<GameObject>();

    public int nowselect = -1;

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
        for (int i = 0; i < Goons.Count-1; i++)
        {
            SelectField[i].SetActive(true);
        }
        for (int i = Goons.Count; i < 10; i++)
        {
            SelectField[i].SetActive(false);
        }


        foreach(var kek in SelectField)
        {
           kek.GetComponent<Outline>().enabled = false;
        }
        if (nowselect != -1)
        {
            SelectField[nowselect].GetComponent<Outline>().enabled = true;
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
                nowselect = i;
            }
            else
            {
                Goons[i].Selected = false;
            }
        }
        SetUI();
    }
    public void Select(Goons idx)
    {
        Debug.Log(idx);
        for (int i = 0; i < Goons.Count; i++)
        {
            if (Goons[i] == idx)
            {
                Goons[i].Selected = true;
                nowselect = i;
            }
            else
            {
                Goons[i].Selected = false;
            }
        }
        SetUI();
    }

    public void Setup()
    {
        nowselect = -1;
        int i = 0;
        foreach(var temp in Goons)
        {
            if (temp.Selected)
            {
                nowselect = i;
            }
            i++;
        }
    }

    void SetUI()
    {
        if (nowselect == -1)
        {
            InventoryUI.Instance.GoonsSelected(null);
        }
        else
        {
            InventoryUI.Instance.GoonsSelected(Goons[nowselect]);
        }
    }
}
