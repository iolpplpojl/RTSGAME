using System.Collections.Generic;
using UnityEngine;

public class IncounterUI : MonoBehaviour
{

    public static IncounterUI instance;
    public GameObject buttonList;
    public GameObject Button;

    public void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }
    }


    public void OpenIncounter()
    {
        gameObject.SetActive(true);
    }

    public void CloseIncounter()
    {
        gameObject.SetActive(false);
    }

    public void setIncounterButton(List<(System.Action, string)> list)
    {
        foreach (var item in list)
        {

        }
    }

}



