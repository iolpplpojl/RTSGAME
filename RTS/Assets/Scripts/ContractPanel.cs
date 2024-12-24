using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Text;
public class ContractPanel : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text _name;
    public TMP_Text _stat;
    public TMP_Text _desc;
    
    GameObject goons;

    public void setButton(GameObject goons)
    {
        this.goons = goons;
        var temp2 = goons.GetComponent<Goons>();
        _name.text = temp2
            ._name;
        StringBuilder query = new StringBuilder();
        var temp = temp2.single.GetComponentInChildren<Player>();
        query.Append(string.Format("최대 체력 : {0}\n", temp.MaxHealth));
        query.Append(string.Format("피해량 : {0}d{1}\n", 1, temp.Damage));
        query.Append(string.Format("공격 : {0}\n", temp.Power));
        query.Append(string.Format("방어 : {0}\n", temp.Defence));
        query.Append(string.Format("개체 수 : {0}\n    ", temp2.MaxCount));
        _stat.text = query.ToString();
        query.Clear();

        //_desc.text = temp2.description;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(goons);
        GoonsManager.instance.addGoons(goons);
        ContractManager.instance.Close();
//         
    }


}