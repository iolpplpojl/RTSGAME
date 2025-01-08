using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Exit", menuName = "Room/Incounter/Exit")]

public class Incounter_Exit : Incounter
{

    public bool firstmove = true;
    public override void Open()
    {

        List<(System.Action, string)> dialogue = new List<(System.Action, string)>();

        dialogue.Add((Dialogue_1, "[내려간다.]"));
        dialogue.Add((Close, "[닫기]"));
        Debug.Log(dialogue);
        IncounterUI.instance.setIncounterButton(dialogue);
        IncounterUI.instance.setText("열려있는 쇠창살 사이로 아래층으로 향하는 계단을 볼 수 있다.");
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
