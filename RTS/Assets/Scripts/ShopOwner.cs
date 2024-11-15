using System.Collections.Generic;
using UnityEngine;

public class ShopOwner : MonoBehaviour
{
    public List<product> storage;
    public int productCount;





    public void SetUp()
    {

        productCount = Random.Range(4, 12);
        for(int i = 0; i < productCount; i++)
        {
            product temp = new product();
            temp.item = ItemDatabase.instance.GetRandomItem();

        }
    }

}


public class product
{
    public Item item;
    public int price;
}