using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GoonsStatusUI : MonoBehaviour
{
    public static GoonsStatusUI instance;
    public Transform parent;
    public GameObject pref;
    public Goons now;
    bool isSetting = false;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }



    public void setUp()
    {
        Debug.Log("¼Â¾÷!");
        Debug.Log(parent + "ÆÐ·±Ã÷");
            if (now != null)
            {
                foreach (Transform temp in parent)
                {
                    temp.gameObject.SetActive(false);
                }
                for (int i = 0; i < now.members.Count; i++)
                {
                    parent.GetChild(i).gameObject.SetActive(true);
                    var kekeke  = now.members[i].GetComponentInChildren<Player>();
                    parent.GetChild(i).GetComponentInChildren<Slider>().value = kekeke.Health / kekeke.MaxHealth;
                    
                }
            }
        
    }

    public void Update()
    {
        setUp();
    }


}
