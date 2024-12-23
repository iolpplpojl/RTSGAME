using UnityEngine;

public class ContractManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static ContractManager instance;
    public Transform parent;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        gameObject.SetActive(false);
    }

    public void setPanel(Contract contract)
    {
        foreach (Transform temp in parent)
        {
            Destroy(temp.gameObject);
        }
    }
}
