using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager instance;

    public GameObject Inventory;

    public GameObject Popup;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int Dice(int times, int max)
    {
        int num = 0;
        for(int i = 0; i < times; i++)
        {
            num += Random.Range(1, max + 1);
        }
        return num;
    }
    public int Dice(int[] list)
    {
        int num = 0;
        for (int i = 0; i < list[0]; i++)
        {
            num += Random.Range(1, list[1] + 1);
        }
        return num;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(!Inventory.activeSelf);
        }
    }
}
