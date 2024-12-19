using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IncounterUI : MonoBehaviour
{

    public static IncounterUI instance;
    public TMP_Text description;
    public GameObject buttonList;
    public GameObject Button;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        gameObject.SetActive(false);
    }


    public void OpenIncounter()
    {
        gameObject.SetActive(true);
    }

    public void CloseIncounter()
    {
        gameObject.SetActive(false);
    }

    public void setText(string Text)
    {
        description.text = Text;
    }
    public void setIncounterButton(List<(System.Action, string)> list)
    {

        foreach (Transform temp in buttonList.transform)
        {
            Destroy(temp.gameObject);
        }

        foreach (var item in list)
        {
            var temp = Instantiate(Button, buttonList.transform);
            temp.GetComponent<DialogueSlot>().setButton(item);
        }
    }

}



