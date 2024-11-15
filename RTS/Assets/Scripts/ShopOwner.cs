using System.Collections.Generic;
using UnityEngine;

public class ShopOwner : MonoBehaviour
{
    public List<product> storage = new List<product>();
    public int productCount;




    public void SetUp()
    {
        storage = new List<product>();
        productCount = Random.Range(4, 12);
        for(int i = 0; i < productCount; i++)
        {
            product temp = new product();
            temp.item = ItemDatabase.instance.GetRandomItem();
            temp.price = temp.item.rare switch
            {
                0 => 50,
                _ => 0,
            };
            storage.Add(temp);
        }
        ShopUI.instance.Setup(this);
    }
        
    public void TestSetUP()
    {
        SetUp();
    }
}


    public class product
    {
        public Item item;
        public int price;
    }