using UnityEngine;
[CreateAssetMenu(fileName = "Contract", menuName = "Contract")]
public class Contract : ScriptableObject,Iitem
{
    [field: SerializeField] public Sprite sprite { get; set; }
    [field: SerializeField] public string itemname { get; set; }
    public string description;
    public int rank;
    public int count;
    public float[,] percent = {
    { 70f, 20f, 8f, 2f, 0f },       // 일반 상자
    { 40f, 35f, 15f, 8f, 2f },      // 고급 상자
    { 20f, 30f, 30f, 15f, 5f },     // 희귀 상자
    { 10f, 20f, 35f, 25f, 10f },    // 영웅 상자
    { 0f, 10f, 30f, 40f, 20f }      // 전설 상자
    };

    public bool use()
    {
        if (GoonsManager.instance.Goons.Count == 10) {
            AlertManager.instance.Append("이미 용병단이 최대 크기에 도달했습니다.");
            return false;
        }
        else
        {
            ContractManager.instance.setPanel(this);
            return true;
        }
    }

    public string getDesc()
    {
        string temp = "";
        temp += description;
        return temp;
    }
}


