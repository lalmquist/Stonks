using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameData : MonoBehaviour
{
    string filepath;
    string saveJSON;
    string readData;
    float moneybuffer = 1f;
    float pricebuffer;
    bool doneLoad = false;

    [SerializeField] public float playerMoney;

    [SerializeField] public Stock Stock1 = new Stock();
    [SerializeField] public Stock Stock2 = new Stock();
    [SerializeField] public Stock Stock3 = new Stock();
    [SerializeField] public Stock Stock4 = new Stock();

    [SerializeField] public Store store = new Store();

    [SerializeField] JSONFileData SaveData = new JSONFileData();
    [SerializeField] JSONFileData LoadData = new JSONFileData();

    [System.Serializable]
    public class Stock
    {
        public float pricePaidForShares;
        public float price;
        public int sharesOwned;
    }

    [System.Serializable]
    public class JSONFileData
    {
        public float playerMoney;
        public Stock stock1;
        public Stock stock2;
        public Stock stock3;
        public Stock stock4;
        public Store store;
    }

    [System.Serializable]
    public class Store
    {
        public bool quantityButton;
        public bool dualMonitors;
    }

    public void SaveJSON()
    {
        saveJSON = JsonUtility.ToJson(SaveData);
        System.IO.File.WriteAllText(filepath, saveJSON);
    }

    public void LoadJSON()
    {
        readData = System.IO.File.ReadAllText(filepath);
        LoadData = JsonUtility.FromJson<JSONFileData>(readData);

        Stock1.price = LoadData.stock1.price;
        Stock1.sharesOwned = LoadData.stock1.sharesOwned;
        Stock1.pricePaidForShares = LoadData.stock1.pricePaidForShares;

        Stock2.price = LoadData.stock2.price;
        Stock2.sharesOwned = LoadData.stock2.sharesOwned;
        Stock2.pricePaidForShares = LoadData.stock2.pricePaidForShares;

        Stock3.price = LoadData.stock3.price;
        Stock3.sharesOwned = LoadData.stock3.sharesOwned;
        Stock3.pricePaidForShares = LoadData.stock3.pricePaidForShares;

        Stock4.price = LoadData.stock4.price;
        Stock4.sharesOwned = LoadData.stock4.sharesOwned;
        Stock4.pricePaidForShares = LoadData.stock4.pricePaidForShares;

        store = LoadData.store;

        playerMoney = LoadData.playerMoney;
        doneLoad = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        filepath = Application.persistentDataPath + "/save.json";
        try
        {
            LoadJSON();
        }
        catch
        {
            
        }
        doneLoad = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (((moneybuffer != playerMoney) || (Stock1.price != pricebuffer)) && (doneLoad == true))
        {

            moneybuffer = playerMoney;
            pricebuffer = Stock1.price;
            SaveData.playerMoney = moneybuffer;

            SaveData.stock1.price = Stock1.price;
            SaveData.stock1.sharesOwned = Stock1.sharesOwned;
            SaveData.stock1.pricePaidForShares = Stock1.pricePaidForShares;

            SaveData.stock2.price = Stock2.price;
            SaveData.stock2.sharesOwned = Stock2.sharesOwned;
            SaveData.stock2.pricePaidForShares = Stock2.pricePaidForShares;

            SaveData.stock3.price = Stock3.price;
            SaveData.stock3.sharesOwned = Stock3.sharesOwned;
            SaveData.stock3.pricePaidForShares = Stock3.pricePaidForShares;

            SaveData.stock4.price = Stock4.price;
            SaveData.stock4.sharesOwned = Stock4.sharesOwned;
            SaveData.stock4.pricePaidForShares = Stock4.pricePaidForShares;

            SaveData.store = store;

            SaveJSON();
        }
    }
}
