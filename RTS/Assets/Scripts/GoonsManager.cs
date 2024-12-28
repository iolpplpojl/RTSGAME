using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GoonsManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GoonsManager instance;
    public List<Goons> Goons = new List<Goons>();
    public List<GameObject> SelectField = new List<GameObject>();

    public int nowselect = -1;

    public GameObject test;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        var temp = transform.childCount;
        for (int i = 0; i < temp; i++)
        {
            Goons.Add(transform.GetChild(i).gameObject.GetComponent<Goons>());
        }
    }

    public bool addGoons(GameObject goons)
    {
        if (Goons.Count != 10) {
            GameObject temp = Instantiate(goons, (Goons[0].GetComponent<Transform>()).position, Quaternion.identity, transform);
            Goons.Add(temp.GetComponent<Goons>());
            Debug.Log("군 추가됨.");
            return true;
        }
        else
        {
            return false;
        }
    }
    public IEnumerator setPos(DungeonManager dungeon) {
        foreach(var kek in Goons)
        {
            Vector3 pos = dungeon.spawnpos[Random.Range(0, dungeon.spawnpos.Count)].position;
            Debug.Log("�׽���");

            foreach (var lol in kek.members)
            {
                Debug.Log("�׽���2");

                lol.GetComponentInChildren<UnityEngine.AI.NavMeshAgent>().Warp(pos);
                lol.GetComponentInChildren<Player>().SetMoveDirection(pos);
            }
        }
        yield return true;

    }
    public void setPos(Vector3 pos)
    {
        foreach (var kek in Goons)
        {
            Debug.Log("�׽���");

            foreach (var lol in kek.members)
            {
                Debug.Log("�׽���2");

                lol.GetComponentInChildren<UnityEngine.AI.NavMeshAgent>().Warp(pos);
                lol.GetComponentInChildren<Player>().SetMoveDirection(pos);
            }
        }
    }
    public void deBuff()
    {
        foreach(var temp in Goons)
        {
            for(int i = temp.buffs.Count-1; i >= 0; i--)
            {
                if (temp.buffs[i].Duration == 0)
                {
                    temp.buffs[i].DeBuff(temp);
                    return;
                }
                temp.buffs[i].Duration--;
            }
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
        Debug.Log(Goons.Count);
        for (int i = Goons.Count; i < 10; i++)
        {
            SelectField[i].SetActive(false);
        }
        for (int i = 0; i < Goons.Count; i++)
        {
            SelectField[i].SetActive(true);
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

    public void Select(List<Goons> idx)
    {
        Debug.Log(idx);
        for (int i = 0; i < Goons.Count; i++)
        {
            if (idx.Contains(Goons[i]))
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

        SetUI();
    }

    void SetUI()
    {
        if (nowselect == -1)
        {
            InventoryUI.Instance.GoonsSelected(null);
            GoonsStatusUI.instance.now = null;
            GoonsStatusUI.instance.setUp();

        }
        else
        {
            InventoryUI.Instance.GoonsSelected(Goons[nowselect]);
            GoonsStatusUI.instance.now = Goons[nowselect];
            GoonsStatusUI.instance.setUp();
        }
    }
}
