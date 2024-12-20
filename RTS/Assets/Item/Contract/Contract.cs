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
       
    }

    public string getDesc()
    {
        string temp = "";
        temp += description;
        return temp;
    }
}


