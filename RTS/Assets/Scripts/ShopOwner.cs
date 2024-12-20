using System.Collections.Generic;
using UnityEngine;

public class ShopOwner
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
            temp.price = Random.Range(30, 120);
            storage.Add(temp);
        }
        Debug.Log("¼¥¿À³Ê »ý¼º");
    }

    public void Show()
    {
        Debug.Log(this + " ¿ÀÇÂ½Ãµµ");
        ShopUI.instance.Setup(this);
    }

    public void TestSetUP()
    {
        SetUp();
    }
}


    public class product
    {
        public Iitem item;
        public int price;
    }