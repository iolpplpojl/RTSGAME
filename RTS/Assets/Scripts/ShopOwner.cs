using System.Collections.Generic;
using UnityEngine;

public class ShopOwner : MonoBehaviour
{
    public List<product> storage;
    public int productCount;


    public void SetUp()
    {
        for(int i = 0; i < productCount; i++)
        {
            product temp = new product();
            temp.item = itemDatabase.instance.GetRandomItem();
        }
    }

}


public class product
{
    public Item item;
    public int price;
}