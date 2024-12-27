using System.Collections.Generic;
using UnityEngine;

public class ShopOwner
{
    public List<product> storage = new List<product>();
    public int productCount;

    public void SetUp()
    {
        storage = new List<product>();
        productCount = GameManager.instance.ShopRandom.Range(4, 12);
        for(int i = 0; i < productCount; i++)
        {
            product temp = new product();
            temp.item = ItemDatabase.instance.GetRandomItem(GameManager.instance.ShopRandom);   
            temp.price = GameManager.instance.ShopRandom.Range(30, 120);
            storage.Add(temp);
        }
        Debug.Log("������ ����");
    }

    public void Show()
    {
        Debug.Log(this + " ���½õ�");
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