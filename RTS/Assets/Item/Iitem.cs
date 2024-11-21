using UnityEngine;

public interface Iitem
{
    public Sprite sprite { get; set; }
    public string itemname { get; set; }
    public string getDesc();
}
