using UnityEngine;

public interface IRoomType 
{
    public void Setup();
    public void Action();

    public bool visited { get; set; }
}
