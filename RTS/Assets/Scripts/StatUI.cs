using UnityEngine;
using TMPro;
using System.Text;

public class StatUI : MonoBehaviour
{
    TMP_Text txt;
    StringBuilder query;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txt = GetComponent<TMP_Text>();
        query = new StringBuilder();
    }

    // Update is called once per frame
    void Update()
    {
        if (InventoryUI.Instance.goons != null)
        {
            var temp = InventoryUI.Instance.goons.members[0].GetComponentInChildren<Player>();
            query.Append(string.Format("�ִ� ü�� : {0}\n", temp.MaxHealth));
            query.Append(string.Format("���ط� : {0}d{1}\n", 1, temp.Damage));
            query.Append(string.Format("���� : {0}\n", temp.Power));
            query.Append(string.Format("��� : {0}\n", temp.Defence));
            query.Append(string.Format("��ü �� : {0}\n    ", InventoryUI.Instance.goons.members.Count));
            txt.text = query.ToString();
            query.Clear();
        }
        else
        {
            txt.text = "";
            query.Clear();
        }
    }
}
        