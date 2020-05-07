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


        if (shares_owned >= shares)
        {
            money = money + (shares * price);

            game_data.playerMoney = money;

            game_data.Stock1.pricePaidForShares = game_data.Stock1.pricePaidForShares - (game_data.Stock1.pricePaidForShares * ((float)shares / (float)shares_owned));

            shares_owned = shares_owned - shares;

            game_data.Stock1.sharesOwned = shares_owned;

            quantity.text = "0";
        }
    }
}
