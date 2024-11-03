using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager instance;


    public GameObject Popup;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
