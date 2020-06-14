﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sell : MonoBehaviour
{
    int shares = 0;


    decimal price = 0;
    decimal money = 0;
    int shares_owned = 0;
    string FadeTextArg;
    decimal math;

    public FadingText fadeText;
    public Number stockNumber;


    GameObject gameData;
    GameData game_data;

    public QuantityMultipler quantity;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void execute()
    {

        if (quantity.multiplier == 0)
        {
            shares = 1;
        }
        else
        {
            shares = quantity.multiplier;
        }

        if (stockNumber.StockNumber == 1)
        {
            price = game_data.Stock1.price;
        }
        else if (stockNumber.StockNumber == 2)
        {
            price = game_data.Stock2.price;
        }
        else if (stockNumber.StockNumber == 3)
        {
            price = game_data.Stock3.price;
        }
        else if (stockNumber.StockNumber == 4)
        {
            price = game_data.Stock4.price;
        }

        money = game_data.playerMoney;

        if (stockNumber.StockNumber == 1)
        {
            shares_owned = game_data.Stock1.sharesOwned;
        }
        else if (stockNumber.StockNumber == 2)
        {
            shares_owned = game_data.Stock2.sharesOwned;
        }
        else if (stockNumber.StockNumber == 3)
        {
            shares_owned = game_data.Stock3.sharesOwned;
        }
        else if (stockNumber.StockNumber == 4)
        {
            shares_owned = game_data.Stock4.sharesOwned;
        }

        if (shares_owned >= shares && shares > 0)
        {
            money = money + (shares * price);

            math = (shares * price);

            FadeTextArg = math.ToString("n2");

            game_data.playerMoney = money;

            if (stockNumber.StockNumber == 1)
            {
                game_data.Stock1.pricePaidForShares = game_data.Stock1.pricePaidForShares - (game_data.Stock1.pricePaidForShares * ((decimal)shares / (decimal)shares_owned));
            }
            else if (stockNumber.StockNumber == 2)
            {
                game_data.Stock2.pricePaidForShares = game_data.Stock2.pricePaidForShares - (game_data.Stock2.pricePaidForShares * ((decimal)shares / (decimal)shares_owned));
            }
            else if (stockNumber.StockNumber == 3)
            {
                game_data.Stock3.pricePaidForShares = game_data.Stock3.pricePaidForShares - (game_data.Stock3.pricePaidForShares * ((decimal)shares / (decimal)shares_owned));
            }
            else if (stockNumber.StockNumber == 4)
            {
                game_data.Stock4.pricePaidForShares = game_data.Stock4.pricePaidForShares - (game_data.Stock4.pricePaidForShares * ((decimal)shares / (decimal)shares_owned));
            }

            shares_owned = shares_owned - shares;

            if (stockNumber.StockNumber == 1)
            {
                game_data.Stock1.sharesOwned = shares_owned;
            }
            else if (stockNumber.StockNumber == 2)
            {
                game_data.Stock2.sharesOwned = shares_owned;
            }
            else if (stockNumber.StockNumber == 3)
            {
                game_data.Stock3.sharesOwned = shares_owned;
            }
            else if (stockNumber.StockNumber == 4)
            {
                game_data.Stock4.sharesOwned = shares_owned;
            }

            fadeText.FadeGreen(FadeTextArg);
        }
    }
}
