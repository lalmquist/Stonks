using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StockPrice : MonoBehaviour
{
    float interval;
    float stock_price = 0;
    float price_buffer;
    float percentVariation;
    float finalVariation;
    float randSeed;
    bool calculatedNew;

    public Number stockNumber;

    GameObject gameData;
    GameData game_data;

    [SerializeField] float stockUpdateTimer = 10f;
    float newInterval;
    TextMeshProUGUI textMesh;
    [SerializeField] float priceVariation;

    [SerializeField] TextMeshProUGUI changeIndicator;


    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
        newInterval = UnityEngine.Random.Range(stockUpdateTimer/2, stockUpdateTimer);
        interval = newInterval;
        changeIndicator.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;

        if (stockNumber.StockNumber == 1)
        {
            stock_price = game_data.Stock1.price;
        }
        else if (stockNumber.StockNumber == 2)
        {
            stock_price = game_data.Stock2.price;
        }
        else if (stockNumber.StockNumber == 3)
        {
            stock_price = game_data.Stock3.price;
        }
        else if(stockNumber.StockNumber == 4)
        {
            stock_price = game_data.Stock4.price;
        }

        textMesh.text = "$" + stock_price.ToString("n2");

        if (interval <= 0.0f)
        {
            updatePrice();
        }
        else if (interval <= newInterval/ 2 && calculatedNew == false)
        {
            timerEnded();
            calculatedNew = true;
        }
    }

    void timerEnded()
    {
        if (stockNumber.StockNumber == 1)
        {
            stock_price = game_data.Stock1.price;
        }
        else if (stockNumber.StockNumber == 2)
        {
            stock_price = game_data.Stock2.price;
        }
        else if (stockNumber.StockNumber == 3)
        {
            stock_price = game_data.Stock3.price;
        }
        else if (stockNumber.StockNumber == 4)
        {
            stock_price = game_data.Stock4.price;
        }

        if (stock_price < 1f)
        {
            randSeed = UnityEngine.Random.Range(99, 100);
        }
        else
        {
            randSeed = UnityEngine.Random.Range(1, 25);
        }

        percentVariation = (stock_price * randSeed) / 100;

        priceVariation = UnityEngine.Random.Range(-percentVariation, percentVariation);

        finalVariation = UnityEngine.Random.Range(-priceVariation, priceVariation);

        if (finalVariation < 0.01f & finalVariation > 0f)
        {
            finalVariation = 0.01f;
        }
        else if (finalVariation > -0.01f & finalVariation < 0f)
        {
            finalVariation = -0.01f;
        }

        if (finalVariation > 0.0f)
        {
            changeIndicator.text = "green";
            changeIndicator.color = new Color32(0, 255, 0, 255);
        }
        else
        {
            changeIndicator.text = "red";
            changeIndicator.color = new Color32(255, 0, 0, 255);
        }
    }

    void updatePrice()
    { 
        stock_price += finalVariation;

        stock_price = (Mathf.Round(stock_price * 100f)) / 100f;

        if (stock_price <= 0.01f)
        {
            stock_price = 0.01f;
        }

        if (stockNumber.StockNumber == 1)
        {
            game_data.Stock1.price = stock_price;
        }
        else if (stockNumber.StockNumber == 2)
        {
            game_data.Stock2.price = stock_price;
        }
        else if (stockNumber.StockNumber == 3)
        {
            game_data.Stock3.price = stock_price;
        }
        else if (stockNumber.StockNumber == 4)
        {
            game_data.Stock4.price = stock_price;
        }


        interval = newInterval;
        calculatedNew = false;

        if (stock_price >= price_buffer)
        {
            textMesh.color = new Color32(0, 255, 0, 255);
        }
        else
        {
            textMesh.color = new Color32(255, 0, 0, 255);
        }

        price_buffer = stock_price;

        changeIndicator.text = "";

    }
}