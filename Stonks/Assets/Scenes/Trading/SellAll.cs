using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SellAll : MonoBehaviour
{
    float price = 0;
    float money = 0;
    int shares_owned = 0;
    string FadeTextArg;
    float math;

    public FadingText fadeText;
    public Number stockNumber;

    GameObject gameData;
    GameData game_data;

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


        if (shares_owned > 0)
        {
            money = money + (shares_owned * price);

            math = (shares_owned * price);

            FadeTextArg = math.ToString("n2");

            game_data.playerMoney = money;

            if (stockNumber.StockNumber == 1)
            {
                game_data.Stock1.pricePaidForShares = 0;
            }
            else if (stockNumber.StockNumber == 2)
            {
                game_data.Stock2.pricePaidForShares = 0;
            }
            else if (stockNumber.StockNumber == 3)
            {
                game_data.Stock3.pricePaidForShares = 0;
            }
            else if (stockNumber.StockNumber == 4)
            {
                game_data.Stock4.pricePaidForShares = 0;
            }

            shares_owned = 0;

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
