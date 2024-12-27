using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Event", menuName = "Room/Incounter/ShopOwner")]
public class Incounter_ShopOwner : Incounter
{

    public ShopOwner owner;
    public bool firstmove = true;
    public override void Open()
    {

        List <(System.Action, string)> dialogue = new List<(System.Action, string)>();

        dialogue.Add((Dialogue_1, "[거래를 시작한다.]"));
        dialogue.Add((Close, "[닫기]"));
        Debug.Log(dialogue);    
        IncounterUI.instance.setIncounterButton(dialogue);
        IncounterUI.instance.setText("\"좋은 날입니다!\" 상인이 말한다, 무거워보이는 배낭에는 먼지가 잔뜩 묻어있다.");
        base.Open();
    }
    public override void Setup()
    {
        if (firstmove)
        {
            owner = new ShopOwner();
            owner.SetUp();
            firstmove = false;
        }
    }
    public override void Close()
    {
        base.Close();
    }
    public void Dialogue_1()
    {
        owner.Show();
    }
}
