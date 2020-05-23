using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StockPrice : MonoBehaviour
{
    float interval;
    float stock_price = 0;
    float price_buffer;

    GameObject gameData;
    GameData game_data;

    [SerializeField] float stockUpdateTimer = 10f;
    TextMeshProUGUI textMesh;
    [SerializeField] float priceVariation = 10f;


    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
        interval = stockUpdateTimer;
    }

    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;

        stock_price = game_data.Stock1.price;

        textMesh.text = "$" + stock_price.ToString("n2");

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

        if (stock_price >= price_buffer)
        {
            textMesh.color = new Color32(0, 255, 0, 255);
        }
        else
        {
            textMesh.color = new Color32(255, 0, 0, 255);
        }

        price_buffer = stock_price;

    }
}