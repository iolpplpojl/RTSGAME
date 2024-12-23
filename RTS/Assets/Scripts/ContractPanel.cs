using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class ContractPanel : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text _name;
    public TMP_Text _stat;
    public TMP_Text _desc;

    GameObject goons;

    public void setButton(GameObject goons)
    {
        this.goons = goons;
       
    }
    public void OnPointerClick(PointerEventData eventData)
    {
//
    }
}