using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StockName : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    GameObject gameData;
    GameData game_data;

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
            textMesh.text = game_data.Stock1.name;
        }
        else if (stockNumber.StockNumber == 2)
        {
            textMesh.text = game_data.Stock2.name;
        }
        else if (stockNumber.StockNumber == 3)
        {
            textMesh.text = game_data.Stock3.name;
        }
        else if (stockNumber.StockNumber == 4)
        {
            textMesh.text = game_data.Stock4.name;
        }
    }
}
