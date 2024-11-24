using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlertManager : MonoBehaviour
{
    public static AlertManager instance;
    Animator anim;
    TMP_Text txt;

    public List<string> alerts = new List<string>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        anim = GetComponent<Animator>();
        txt = GetComponentInChildren<TMP_Text>();
    }



    private void Update()
    {
        var info = anim.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Burn") == true)
        {
            Debug.Log("Àç»ýÁß");
        }
        else
        {
            if (alerts.Count > 0)
            {
                doAlert();
            }
        }
    }
    public void Append(string text)
    {
        alerts.Add(text);
    }
    public void doAlert()
    {
        string text = alerts[0];
        alerts.RemoveAt(0);
        txt.text = text;
        anim.Play("Burn");
    }
}
