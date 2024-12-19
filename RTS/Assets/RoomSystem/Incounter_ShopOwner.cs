using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Event", menuName = "Room/Incounter/ShopOwner")]
public class Incounter_ShopOwner : Incounter
{

    public override void Open()
    {

        List <(System.Action, string)> dialogue = new List<(System.Action, string)>();

        dialogue.Add((Dialogue_1, "[�ŷ��� �����Ѵ�.]"));
        dialogue.Add((Close, "[�ݱ�]"));
        Debug.Log(dialogue);    
        IncounterUI.instance.setIncounterButton(dialogue);
        IncounterUI.instance.setText("\"���� ���Դϴ�!\" ������ ���Ѵ�, ���ſ����̴� �賶���� ������ �ܶ� �����ִ�.");
        base.Open();
    }

    public override void Close()
    {
        base.Close();
    }
    public void Dialogue_1()
    {

    }
}
