using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class DialogueSlot : MonoBehaviour, IPointerClickHandler
{
    public System.Action method;
    public TMP_Text txt;


    public void setButton((System.Action, string) action)
    {
        method = action.Item1;
        txt.text = action.Item2;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        method();
    }
}