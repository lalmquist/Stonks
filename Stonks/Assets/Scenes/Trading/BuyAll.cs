using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyAll : MonoBehaviour
{
    float price = 0;
    float money = 0;
    int shares_owned = 0;
    string FadeTextArg;
    float math;

    public FadingText fadeText;
    public Number stockNumber;

    public CanvasGroup canvasGroup;

    [SerializeField] public MaxBuyPossible maxBuyPossible;

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
        if (game_data.store.buyAll)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
        }
        else
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
        }
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

        money -= (maxBuyPossible.maxbuy_int * price);

        math = (maxBuyPossible.maxbuy_int * price);

        FadeTextArg = math.ToString("n2");

        game_data.playerMoney = money;

        if (stockNumber.StockNumber == 1)
        {
            game_data.Stock1.pricePaidForShares += (maxBuyPossible.maxbuy_int * price);
        }
        else if (stockNumber.StockNumber == 2)
        {
            game_data.Stock2.pricePaidForShares += (maxBuyPossible.maxbuy_int * price);
        }
        else if (stockNumber.StockNumber == 3)
        {
            game_data.Stock3.pricePaidForShares += (maxBuyPossible.maxbuy_int * price);
        }
        else if (stockNumber.StockNumber == 4)
        {
            game_data.Stock4.pricePaidForShares += (maxBuyPossible.maxbuy_int * price);
        }

        shares_owned += maxBuyPossible.maxbuy_int;

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

        fadeText.FadeRed(FadeTextArg);
    }
}
