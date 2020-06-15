﻿using System.Collections;
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
    float randSeed;
    bool ONS;

    public Number stockNumber;

    GameObject gameData;
    GameData game_data;

    [SerializeField] float stockUpdateTimer = 10f;
    TextMeshProUGUI textMesh;
    [SerializeField] float priceVariation;


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
            if (ONS == false)
            {
                ONS = true;
                timerEnded();
            }
        }
    }

    void timerEnded()
    {
        if (stockNumber.StockNumber == 1)
        {
            stock_price = game_data.Stock1.price;
        }
        else if(stockNumber.StockNumber == 2)
        {
            stock_price = game_data.Stock2.price;
        }
        else if(stockNumber.StockNumber == 3)
        {
            stock_price = game_data.Stock3.price;
        }
        else if(stockNumber.StockNumber == 4)
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

        Debug.Log("percent variation" + percentVariation);
        //Debug.Log("stock price" + stock_price);

        //priceVariation = UnityEngine.Random.Range(-percentVariation, percentVariation);
        priceVariation = percentVariation;

        //stock_price += UnityEngine.Random.Range(-priceVariation, priceVariation);
        stock_price += priceVariation;

        //Debug.Log(stock_price);

        stock_price = (Mathf.Round(stock_price * 10f)) / 10f;
        
        //Debug.Log(stock_price);

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