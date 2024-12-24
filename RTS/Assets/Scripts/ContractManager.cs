using UnityEngine;

public class ContractManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static ContractManager instance;
    public Transform parent;
    public GameObject pref;

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
        for(int i = 0; i < contract.count; i++)
        {
            var temp = Random.value;
            int tempRank = 0;
            for (int k = contract.percent.GetLength(1)-1; k >= 0 ; k--)
            {
                if (temp > contract.percent[contract.rank, k])
                {
                    tempRank = k;
                    break;
                }
            }
            GameObject goons = null;
            goons = ItemDatabase.instance.GetRandomGoons(tempRank);
            GameObject keke = Instantiate(pref, parent);

            keke.GetComponent<ContractPanel>().setButton(goons);
        }

        gameObject.SetActive(true);
        

 
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
