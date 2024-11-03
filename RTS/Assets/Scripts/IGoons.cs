using System.Collections.Generic;
using UnityEngine;

public interface IGoons
{
    List<GameObject> members { get; set; }
    public GameObject SetTargeting();
    public void memberDie(GameObject member);

}
