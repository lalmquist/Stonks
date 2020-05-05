using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    string filepath;
    string saveJSON;
    string moneybuffer;
    string readData;
    bool doneLoad = false;
    [SerializeField] Data SaveData = new Data();
    [SerializeField] Data LoadData = new Data();

    [SerializeField] TextMeshProUGUI playerMoney;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney.text = "1000";
        filepath = Application.persistentDataPath + "/save.json";
        LoadJSON();
    }

    [System.Serializable]
    public class Data
    {
        public string money;
    }


    // Update is called once per frame
    void Update()
    {
        if ((moneybuffer != playerMoney.text) && (doneLoad == true))
        {
            moneybuffer = playerMoney.text;
            SaveData.money = moneybuffer;
            SaveJSON();
        }
        
    }

    public void SaveJSON()
    {
        saveJSON = JsonUtility.ToJson(SaveData);
        System.IO.File.WriteAllText(filepath, saveJSON);
    }

    public void LoadJSON()
    {
        readData = System.IO.File.ReadAllText(filepath);
        LoadData = JsonUtility.FromJson<Data>(readData);
        playerMoney.text = LoadData.money.ToString();
        doneLoad = true;
    }
}
