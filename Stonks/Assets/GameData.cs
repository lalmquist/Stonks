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
            SaveJSON();
        }


        
    }
}
