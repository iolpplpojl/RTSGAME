using System.Dynamic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ShopOwner owner;
    public static ShopUI instance;
    public GameObject parent;
    public GameObject prefab;
    


    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        gameObject.SetActive(false);
    }


    public void Setup(ShopOwner owner)
    {
        Debug.Log(owner + "¿ÀÇÂ");
        this.owner = owner;
        foreach (Transform temp in parent.transform)
        {
            Destroy(temp.gameObject);
        }
        int i = 0;

        foreach (var temp in owner.storage)
        {
            var kek = Instantiate(prefab, parent.transform);
            var pepe = kek.GetComponent<ShopSlot>();
            pepe.data = temp;
        }
        gameObject.SetActive(true);
    }

    public void Buy(ShopSlot slot)
    {
        if (GameManager.instance.gold > slot.data.price)
        {

            for (int i = 0; i < GameManager.instance.storageCount; i++)
            {
                if (GameManager.instance.storage[i] == null)
                {
                    GameManager.instance.storage[i] = slot.data.item;
                    owner.storage.Remove(slot.data);

                    Setup(owner);


                    return;
                }
            }
            Debug.Log("ÀÎº¥ ¸ðÀÚ¶÷!!");
        }
        else
        {
            Debug.Log("µ· ¾øÀ½!!");
        }
    }
    public void Sell()
    {

    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
