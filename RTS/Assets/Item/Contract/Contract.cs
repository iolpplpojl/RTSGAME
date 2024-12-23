using UnityEngine;
[CreateAssetMenu(fileName = "Contract", menuName = "Contract")]
public class Contract : ScriptableObject,Iitem
{
    [field: SerializeField] public Sprite sprite { get; set; }
    [field: SerializeField] public string itemname { get; set; }
    public string description;
    public int rank;


    public bool use()
    {
        if (GoonsManager.instance.Goons.Count == 10) {
            AlertManager.instance.Append("이미 용병단의 최대 크기에 도달했습니다.");
            return false;
        }
        else
        {
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


