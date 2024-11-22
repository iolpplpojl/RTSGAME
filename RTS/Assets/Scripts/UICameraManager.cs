using UnityEngine;
using UnityEngine.UI;

public class UICameraManager : MonoBehaviour
{
    public static UICameraManager instance;
    public Canvas can;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            can = GetComponent<Canvas>();
        }
    }
}
