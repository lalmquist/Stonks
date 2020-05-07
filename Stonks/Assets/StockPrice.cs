using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StockPrice : MonoBehaviour
{
    float interval;
    float stock_price = 0;

    GameObject gameData;
    GameData game_data;

    [SerializeField] float stockUpdateTimer;
    [SerializeField] TextMeshProUGUI stockPrice;
    [SerializeField] float priceVariation = 10f;


    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
        interval = stockUpdateTimer;
    }

    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;

        stock_price = game_data.Stock1.price;

        stockPrice.text = "$" + stock_price.ToString("#.00");

        if (interval <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        stock_price = game_data.Stock1.price;

        stock_price = stock_price + Random.Range(-priceVariation, priceVariation);

        game_data.Stock1.price = stock_price;

        interval = stockUpdateTimer;

    }
}