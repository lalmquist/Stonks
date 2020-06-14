using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MaxBuyPossible : MonoBehaviour
{
    GameObject gameData;
    GameData game_data;

    public int maxbuy_int;
    decimal maxbuy_decimal;

    public decimal price;

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

        maxbuy_decimal = game_data.playerMoney / price;

        maxbuy_int = Convert.ToInt32(maxbuy_decimal);

        if (price == 0)
        {
            maxbuy_int = 0;
        }

        textMesh.text = maxbuy_int.ToString("#,#");
    }
}
