using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxBuyPossible : MonoBehaviour
{
    GameObject gameData;
    GameData game_data;

    int maxbuy_int;
    float maxbuy_float;
    public Number stockNumber;
    bool Zero;

    TextMeshProUGUI textMesh;

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
        Zero = false;

        if (stockNumber.StockNumber == 1)
        {
            maxbuy_float = game_data.playerMoney / game_data.Stock1.price;
            if (game_data.Stock1.price == 0f)
            {
                Zero = true;
            }
        }
        else if (stockNumber.StockNumber == 2)
        {
            maxbuy_float = game_data.playerMoney / game_data.Stock2.price;
            if (game_data.Stock2.price == 0f)
            {
                Zero = true;
            }
        }
        else if (stockNumber.StockNumber == 3)
        {
            maxbuy_float = game_data.playerMoney / game_data.Stock3.price;
            if (game_data.Stock3.price == 0f)
            {
                Zero = true;
            }
        }
        else if (stockNumber.StockNumber == 4)
        {
            maxbuy_float = game_data.playerMoney / game_data.Stock4.price;
            if (game_data.Stock4.price == 0f)
            {
                Zero = true;
            }
        }

        maxbuy_int = Mathf.FloorToInt(maxbuy_float);

        if (Zero == true)
        {
            maxbuy_int = 0;
        }

        textMesh.text = maxbuy_int.ToString("#,#");
    }
}
