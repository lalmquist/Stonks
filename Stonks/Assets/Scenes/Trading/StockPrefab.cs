using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockPrefab : MonoBehaviour
{
    GameObject gameData;
    GameData game_data;


    public GameData.Stock stock;
    public int stockNumber;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        parseStockNumber();
    }

    void parseStockNumber()
    {
        switch (stockNumber)
        {
            case 1:
                stock = game_data.Stock1;
                break;
            case 2:
                stock = game_data.Stock2;
                break;
            case 3:
                stock = game_data.Stock3;
                break;
            case 4:
                stock = game_data.Stock4;
                break;
            default:
                Debug.Log("Default case");
                break;
        }
    }
}
