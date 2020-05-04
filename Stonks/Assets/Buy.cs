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
    [SerializeField] TextMeshProUGUI playerMoney;
    [SerializeField] TextMeshProUGUI SharesOwned;


    // Start is called before the first frame update
    void Start()
    {
        SharesOwned.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void execute()
    {
        int.TryParse(quantity.text, out shares);
        float.TryParse(stock.text, out price);
        float.TryParse(playerMoney.text, out money);
        int.TryParse(SharesOwned.text, out shares_owned);

        bufferMoney = money;

        bufferMoney = money - (shares * price);

        if (bufferMoney >= 0)
        {
            money = money - (shares * price);

            playerMoney.text = money.ToString();

            shares_owned = shares_owned + shares;

            SharesOwned.text = shares_owned.ToString();

            quantity.text = "0";
        }
    }
}
