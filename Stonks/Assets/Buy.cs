using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buy : MonoBehaviour
{
    int shares = 0;
    float price = 0;
    float money = 0;
    int shares_owned = 0;
    float bufferMoney = 0;

    [SerializeField] TextMeshProUGUI quantity;
    [SerializeField] TextMeshProUGUI stock;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void execute()
    {
        int.TryParse(quantity.text, out shares);
        float.TryParse(stock.text, out price);

        GameObject gameData = GameObject.Find("GameData");
        GameData game_data = gameData.GetComponent<GameData>();

        money = game_data.playerMoney;

        bufferMoney = money;

        bufferMoney = money - (shares * price);

        if (bufferMoney >= 0)
        {
            money = money - (shares * price);

            game_data.playerMoney = money;

            shares_owned = game_data.Stock1.sharesOwned;

            shares_owned = shares_owned + shares;

            game_data.Stock1.sharesOwned = shares_owned;

            game_data.pricePaid = shares * price;

            quantity.text = "0";
        }
    }
}
