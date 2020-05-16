using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sell : MonoBehaviour
{
    int shares = 0;
    float price = 0;
    float money = 0;
    int shares_owned = 0;
    string FadeTextArg;
    float math;

    public FadingText fadeText;

    [SerializeField] TextMeshProUGUI quantity;

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
        int.TryParse(quantity.text, out shares);

        price = game_data.Stock1.price;

        money = game_data.playerMoney;

        shares_owned = game_data.Stock1.sharesOwned;


        if (shares_owned >= shares && shares > 0)
        {
            money = money + (shares * price);

            math = (shares * price);

            FadeTextArg = math.ToString("#.00");

            game_data.playerMoney = money;

            game_data.Stock1.pricePaidForShares = game_data.Stock1.pricePaidForShares - (game_data.Stock1.pricePaidForShares * ((float)shares / (float)shares_owned));

            shares_owned = shares_owned - shares;

            game_data.Stock1.sharesOwned = shares_owned;

            fadeText.FadeGreen(FadeTextArg);

            quantity.text = "0";
        }
    }
}
