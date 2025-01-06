using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dungeon", menuName = "Room/Dungeon")]

public class RoomType_Dungeon : ScriptableObject, IRoomType
{
    public GameObject Dungeon;
    public List<GameObject> enemySpawn;
    public bool visited;

    public void Setup()
    {
        Dungeon = ItemDatabase.instance.GetRandomRoom();
        enemySpawn = new List<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            if(i == 0)
            {
                GameObject temp = ItemDatabase.instance.GetEnemyGoons();

                enemySpawn.Add(temp);
            }
            else if (GameManager.instance.SpawnerRandom.Range(0f, 1f) > 0.3f)
            {
                GameObject temp = ItemDatabase.instance.GetEnemyGoons();
                enemySpawn.Add(temp);
            }
        }
        Debug.Log("´øÀü»ý¼ºµÊ" + Dungeon + enemySpawn.Count);

    }
    public void Action()
    {
        if (visited == false)
        {
            visited = true;
            GameManager.instance.ExecuteDungeonEnter(Dungeon,enemySpawn);
        }
    }
}
