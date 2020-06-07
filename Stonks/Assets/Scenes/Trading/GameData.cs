﻿using System.Collections;
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
        public string name;
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
        public bool sellAll;
        public bool buyAll;
        public bool unlockStock2;
        public bool unlockStock3;
        public bool unlockStock4;
        public float storeMultiplier;
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

        Stock1 = LoadData.stock1;
        Stock2 = LoadData.stock2;
        Stock3 = LoadData.stock3;
        Stock4 = LoadData.stock4;

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
        if (((moneybuffer != playerMoney) || (Stock1.price != pricebuffer) || (SaveData.store != store)) && (doneLoad == true))
        {

            moneybuffer = playerMoney;
            pricebuffer = Stock1.price;
            SaveData.playerMoney = moneybuffer;

            SaveData.stock1 = Stock1;
            SaveData.stock2 = Stock2;
            SaveData.stock3 = Stock3;
            SaveData.stock4 = Stock4;

            SaveData.store = store;

            SaveJSON();
        }
    }
}
