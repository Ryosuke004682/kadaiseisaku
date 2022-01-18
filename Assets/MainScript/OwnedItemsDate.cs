using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OwnedItemsDate
{
    private const string PlayerPrefsKey = "OWNED_ITEM_DATA";

    public static OwnedItemsDate Instance
    {
        get
        {
            if(null == _instance)
            {
                _instance = PlayerPrefs.HasKey(PlayerPrefsKey) ? JsonUtility
                    .FromJson<OwnedItemsDate>(PlayerPrefs.
                    GetString(PlayerPrefsKey)) : new OwnedItemsDate();
            }
            return _instance;
        }
    }

    private static OwnedItemsDate _instance;

    public OwnedItem[] OwnedItems
    {
        get { return ownedItems.ToArray(); }
    }

    [SerializeField]
    private List<OwnedItem> ownedItems
         = new List<OwnedItem>();

    private OwnedItemsDate()
    {

    }

    public void Save ()
    {
        var jsonString = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(PlayerPrefsKey , jsonString);
        PlayerPrefs.Save();
    }

    public void Add(Item.ItemType type , int number = 1)
    {
        var item = GetItem(type);
        if (null == item)
        {
            item = new OwnedItem(type);
            ownedItems.Add(item);
        }
        item.Add(number);
    }
    public void Use(Item.ItemType type,int number = 1)
    {
        var item = GetItem(type);
        if (null == item || item.Number < number)
        {
            throw new Exception("アイテムが足りません");
        }
        item.Use(number);
    }
    
    public OwnedItem GetItem(Item.ItemType type)
    {
        return ownedItems.FirstOrDefault
            (x => x.Type == type);
    }

    [Serializable]
    public class OwnedItem
    {
        public Item.ItemType Type
        {
            get { return type;  }
        }
        public int Number
        {
            get { return number; }
        }
        [SerializeField] private Item.ItemType type;
        [SerializeField] private int number;

        public OwnedItem(Item.ItemType type)
        {
            this.type = type;
        }
        public void Add(int number = 1)
        {
            this.number += number;
        }
        public void Use(int number = 1)
        {
            this.number -= number;
        }

    }



}
