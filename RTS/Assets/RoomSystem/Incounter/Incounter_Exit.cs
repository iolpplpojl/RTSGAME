using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Exit", menuName = "Room/Incounter/Exit")]

public class Incounter_Exit : Incounter
{

    public bool firstmove = true;
    public override void Open()
    {

        List<(System.Action, string)> dialogue = new List<(System.Action, string)>();

        dialogue.Add((Dialogue_1, "[��������.]"));
        dialogue.Add((Close, "[�ݱ�]"));
        Debug.Log(dialogue);
        IncounterUI.instance.setIncounterButton(dialogue);
        IncounterUI.instance.setText("�����ִ� ��â�� ���̷� �Ʒ������� ���ϴ� ����� �� �� �ִ�.");
        base.Open();
    }
    public override void Setup()
    {
        //
    }
    public override void Close()
    {
        base.Close();
    }
    public void Dialogue_1()
    {
        GameManager.instance.toNextFloor();
        Close();
    }
}
