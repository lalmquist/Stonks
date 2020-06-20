using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyIfSold : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    [SerializeField] public TextMeshProUGUI holdings;

    GameObject gameData;
    GameData game_data;

    float possibleSell;
    float netDifference;
    public Number stockNumber;


    // Start is called before the first frame update
    void Start()
    { 
        textMesh = GetComponent<TextMeshProUGUI>();
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {

        if (stockNumber.StockNumber == 1)
        {
            possibleSell = game_data.Stock1.price * game_data.Stock1.sharesOwned;
        }
        else if (stockNumber.StockNumber == 2)
        {
            possibleSell = game_data.Stock2.price * game_data.Stock2.sharesOwned;
        }
        else if (stockNumber.StockNumber == 3)
        {
            possibleSell = game_data.Stock3.price * game_data.Stock3.sharesOwned;
        }
        else if (stockNumber.StockNumber == 4)
        {
            possibleSell = game_data.Stock4.price * game_data.Stock4.sharesOwned;
        }

        holdings.text = possibleSell.ToString("n2");

        if (stockNumber.StockNumber == 1)
        {
            netDifference = possibleSell - game_data.Stock1.pricePaidForShares;
            if (game_data.Stock1.sharesOwned == 0)
            {
                textMesh.text = "";
            }
        }
        else if (stockNumber.StockNumber == 2)
        {
            netDifference = possibleSell - game_data.Stock2.pricePaidForShares;
            if (game_data.Stock2.sharesOwned == 0)
            {
                textMesh.text = "";
            }
        }
        else if (stockNumber.StockNumber == 3)
        {
            netDifference = possibleSell - game_data.Stock3.pricePaidForShares;
            if (game_data.Stock3.sharesOwned == 0)
            {
                textMesh.text = "";
            }
        }
        else if (stockNumber.StockNumber == 4)
        {
            netDifference = possibleSell - game_data.Stock4.pricePaidForShares;
            if (game_data.Stock4.sharesOwned == 0)
            {
                textMesh.text = "";
            }
        }

        if (netDifference > 0)
        {
            textMesh.text = "$" + netDifference.ToString("n2");
            textMesh.color = new Color32(0, 255, 0, 255);
        }
        else if (netDifference == 0)
        {
            textMesh.text = "$0.00";
            textMesh.color = new Color32(0, 255, 0, 255);
        }
        else
        {
            textMesh.text = "-" + "$" + Mathf.Abs(netDifference).ToString("n2");
            textMesh.color = new Color32(255, 0, 0, 255);
        }
    }
}
